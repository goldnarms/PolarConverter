/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";
    declare var TimeZoneDB;
    export interface IUploadController {
        injection(): any[];
        options: any;
        loadingFiles: boolean;
        queue: any[];
        uploadedFiles: PolarFile[];
        dropboxFiles: PolarFile[];
        gpxFiles: GpxFile[];
        convertedFiles: File[];
        sports: any[];
        isMetricWeight: boolean;
        timeZones: TimeZone[];
        uploadViewModel: UploadViewModel;
        checkForMatchingFile(list: File[], fileName: string): File;
        setWeightTypeBasedOnCountry(countryCode: string): void;
        setTimeZoneOffset(timeZone: TimeZone): void;
        reset(): void;
        initPage(): void;
        convert(uploadViewModel: UploadViewModel): void;
        removeGpxFile(polarFile: PolarFile): void;
        getFilesFromDropbox(): void;
        isConverting: boolean;
        showExtraVariables: boolean;
        shareToFacebook(): void;
        tweetText: string;
        showErrors: boolean;
        showFileTable: boolean;
        showUploadedFiles: boolean;
        selectedTimeZone: TimeZone;
        userProfileForm: ng.IFormController;
    }

    export class UploadController {
        public injection(): any[] {
            return ["$scope", "$http", "$filter", "$window", "$document", "common", "localStorageService", "facebookShareService", "userService", "fileService", UploadController];
        }
        static $inject = ["$scope", "$http", "$filter", "$window", "$document", "common", "localStorageService", "facebookShareService", "userService", "fileService"];
        public options: any;
        public loadingFiles: boolean;
        public queue: any[];
        public uploadedFiles: PolarFile[];
        public gpxFiles: GpxFile[];
        public convertedFiles: File[];
        public uploadViewModel: UploadViewModel;
        public isMetricWeight: boolean;
        public isConverting: boolean;
        public showExtraVariables: boolean;
        public timeZones: TimeZone[];
        public sports: any[];
        public errors: string[];
        public tweetText: string;
        public showErrors: boolean;
        public selectedTimeZone: TimeZone;
        public userProfileForm: ng.IFormController;
        private initalized: boolean = false;
        private showUploadedFiles: boolean;
        private showFileTable: boolean = true;

        constructor(private $scope: ng.IScope, private $http: ng.IHttpService, private $filter: ng.IFilterService, private $window: ng.IWindowService, private $document: any, private common: ICommonService, private storage: IStorage, private facebookShareService: IFacebookShareService, private userService: IUserService, private fileService: IFileService) {
            this.init();
            this.setupWatches();
        }

        private init(): void {
            this.common.loadingBar.start();
            this.setTimeZones();
            this.uploadedFiles = [];
            this.convertedFiles = [];
            this.gpxFiles = [];
            this.sports = [];
            this.errors = [];
            this.showUploadedFiles = true;
            this.showFileTable = true;
            this.showErrors = false;
            for (var sport in PolarConverter.sportEnum) {
                if (typeof PolarConverter.sportEnum[sport] === "number") {
                    this.sports.push(sport);
                }
            }

            this.tweetText = "I have just converted my Polar files to Endomondo compatible files using #polarconverter at ";
            this.isMetricWeight = true;
            this.isConverting = false;
            this.uploadViewModel = <PolarConverter.UploadViewModel>{ polarFiles: [], forceGarmin: false, gender: "m" };
            var url = "/api/upload";
            this.options = {
                autoUpload: true,
                acceptFileTypes: /(\.|\/)(gpx|hrm|xml)$/i,
                url: url,
                dataType: "json"
            };
            this.loadingFiles = true;
            //this.$http({ method: "jsonp", url: "http://ipinfo.io/?callback=callback"}).success((data, status, headers, config) => {
            //    this.setWeightTypeBasedOnCountry(data.country);
            //})
            //.error((data, status, headers, config) => {
            //    this.$log.error(status);
            //});
            $.get("http://ipinfo.io", (response) => {
                this.setWeightTypeBasedOnCountry(response.country);
                var loc = response.loc;
                var lat = loc.substring(0, loc.indexOf(","));
                var lng = loc.substring(loc.indexOf(",") + 1, loc.length);
                this.setTimeZoneOffsetBasedOnCountry(lat, lng);
            }, "jsonp");

            if (this.initalized) {
                this.$http.get(url)
                    .then(
                    (response) => {
                        this.common.log.info(response);
                        this.loadingFiles = false;
                        this.queue = response.data.files || [];
                    },
                    () => {
                        this.loadingFiles = false;
                    });
                this.initalized = true;
            }
            this.common.loadingBar.complete();
        }

        public callback(data: any): void {
            this.common.log.info(data);
        }

        public shareToFacebook(): void {
            this.facebookShareService.openDialogue();
        }

        public getFilesFromDropbox(): void {
            this.userService.getUserId().then((userId) => {
                this.common.log.info("Userid: " + userId.data);
                this.fileService.getDropboxFilesForUser(userId.data)
                    .success((data) => {
                        this.common.log.info(JSON.stringify(data));
                        _.each(data, (dropboxFile: any) => {
                            this.showExtraVariables = dropboxFile.showExtraVariables;
                            if (dropboxFile.fileType === "gpx") {
                                var gpxFile = this.mapGpxFile(dropboxFile, true);
                                this.gpxFiles.push(gpxFile);
                                var matchingPolarFile = <PolarConverter.PolarFile> this.checkForMatchingFile(this.uploadedFiles, gpxFile.name);
                                if (matchingPolarFile) {
                                    gpxFile.matched = true;
                                    matchingPolarFile.gpxFile = gpxFile;
                                }
                            } else {
                                if (dropboxFile.weight) {
                                    this.uploadViewModel.weight = dropboxFile.weight;
                                }
                                var polarFile = this.mapPolarFile(dropboxFile, true);
                                this.uploadedFiles.push(polarFile);
                                var matchingGpxFile = <PolarConverter.GpxFile> this.checkForMatchingFile(this.gpxFiles, polarFile.name);
                                if (matchingGpxFile) {
                                    polarFile.gpxFile = matchingGpxFile;
                                    matchingGpxFile.matched = true;
                                }
                            }
                        });
                        this.common.loadingBar.complete();

                    })
                    .catch((error) => {
                        this.common.log.error("Error: " + error);
                    });
            });
        }

        private onError(data: any): void {
            this.common.log.error(data);
            this.common.loadingBar.complete();
        }

        private onUpload(data: any): void {
            this.showExtraVariables = data.result.showExtraVariables;
            if (data.result.fileType === "gpx") {
                var gpxFile = this.mapGpxFile(data.result, false);
                this.gpxFiles.push(gpxFile);
                var matchingPolarFile = <PolarConverter.PolarFile> this.checkForMatchingFile(this.uploadedFiles, gpxFile.name);
                if (matchingPolarFile) {
                    gpxFile.matched = true;
                    matchingPolarFile.gpxFile = gpxFile;
                }
            } else {
                if (data.result.weight) {
                    this.uploadViewModel.weight = data.result.weight;
                }
                var polarFile = this.mapPolarFile(data.result, false);
                this.uploadedFiles.push(polarFile);
                var matchingGpxFile = <PolarConverter.GpxFile> this.checkForMatchingFile(this.gpxFiles, polarFile.name);
                if (matchingGpxFile) {
                    polarFile.gpxFile = matchingGpxFile;
                    matchingGpxFile.matched = true;
                }
            }
            this.common.loadingBar.complete();
            this.showFileTable = false;
        }

        private mapPolarFile(file: any, fromDropbox: boolean): PolarFile {
            return <PolarFile>{
                fileType: file.fileType,
                name: file.name,
                reference: file.reference,
                sport: file.sport,
                checked: !fromDropbox,
                fromDropbox: fromDropbox
            };
        }

        private mapGpxFile(file: any, fromDropbox: boolean): GpxFile {
            return <GpxFile>{
                name: file.name,
                reference: file.reference,
                matched: false,
                version: file.gpxVersion,
                fromDropbox: fromDropbox
            };
        }

        private setupWatches(): void {
            this.$scope.$on("fileuploadfail", (event, data) => {
                this.onError(data);
            });
            this.$scope.$on("fileuploaddone", (event, data) => {
                this.onUpload(data);
            });
        }

        public checkForMatchingFile(list: PolarConverter.File[], fileName: string): PolarConverter.File {
            return _.find(list, (file: PolarConverter.File) => {
                return file.name.substring(0, file.name.length - 4) === fileName.substring(0, file.name.length - 4);
            });
        }

        public setWeightTypeBasedOnCountry(countryCode: string): void {
            var imperialCountries = ["US", "GB", "LR", "MM"];
            this.isMetricWeight = !_.contains(imperialCountries, countryCode);
            this.uploadViewModel.weightMode = this.isMetricWeight ? "kg" : "lbs";
        }

        private setTimeZoneOffsetBasedOnCountry(lat: string, lng: string): void {
            var tzDb = new TimeZoneDB;
            tzDb.getJSON({
                key: PolarConverter.Config.TimeZoneDBKey,
                lat: lat,
                lng: lng
            }, (data) => {
                    var daylightSavings = data.dst;
                    var timeZoneOffsetInHours = data.gmtOffset / 3600;
                    if (daylightSavings === "1") {
                        timeZoneOffsetInHours--;
                    }
                    this.selectedTimeZone = _.find(this.timeZones, (tz: PolarConverter.TimeZone) => {
                        return tz.offset === timeZoneOffsetInHours;
                    });
                    this.$scope.$apply();
                });
        }

        public initPage(): void {
            this.reset();
            this.$scope.$broadcast("clearFiles");
            this.$document.scrollTop(0, 1000);
        }

        public reset(): void {
            this.showFileTable = true;
            this.showUploadedFiles = true;
            this.gpxFiles = [];
            this.uploadedFiles = [];
            this.convertedFiles = [];
            this.errors = [];
            this.showErrors = false;
            this.common.loadingBar.complete();
        }
        public removeGpxFile(polarFile: PolarConverter.PolarFile) {
            polarFile.gpxFile.matched = false;
            polarFile.gpxFile = null;
        }

        public setTimeZoneOffset(timeZone: PolarConverter.TimeZone): void {
            this.uploadViewModel.timeZoneOffset = timeZone.offset;
            this.storage.add("TimeZoneOffset", timeZone.offset);
        }

        public convert(uploadViewModel: PolarConverter.UploadViewModel): void {
            this.common.loadingBar.start();
            this.showUploadedFiles = false;
            this.isConverting = true;
            this.uploadViewModel.polarFiles = _.filter(this.uploadedFiles, (uf: PolarFile) => { return uf.checked; });
            this.common.log.info("Sent to uplpoad: " + JSON.stringify(this.uploadViewModel));
            this.uploadViewModel.timeZoneOffset = this.selectedTimeZone.offset;
            this.userService.getUserId().then((userId) => {
                this.uploadViewModel.uid = userId.data;
                this.$http.post("/api/convert", this.uploadViewModel, { tracker: "convertDone" }).then((response) => {
                    this.onSuccesssfullConvert(response);
                });
            });
        }

        private onSuccesssfullConvert(response): void {
            if (response.data.ErrorMessages && response.data.ErrorMessages.length > 0) {
                this.errors = response.data.ErrorMessages;
                this.showErrors = true;
            }
            if (response.data.Reference != null) {
                this.convertedFiles.push(<PolarConverter.File>{ name: response.data.FileName, reference: response.data.Reference });
            } else {
                this.showErrors = true;
            }
            this.isConverting = false;
            this.uploadedFiles = [];
            this.gpxFiles = [];
            this.$document.scrollTop(350, 1000);
            this.common.loadingBar.complete();
        }

        private setTimeZones() {
            this.timeZones = [
                { offset: -12, text: "(GMT -12:00) Etc/GMT" },
                { offset: -11, text: "(GMT -11:00) Pacific/Pago_Pago" },
                { offset: -10, text: "(GMT -10:00) America/Adak" },
                { offset: -10, text: "(GMT -10:00) Pacific/Honolulu" },
                { offset: -9.5, text: "(GMT -9:30) Pacific/Marquesas" },
                { offset: -9, text: "(GMT -9:00) Pacific/Gambier" },
                { offset: -9, text: "(GMT -9:00) America/Anchorage" },
                { offset: -8, text: "(GMT -8:00) America/Los_Angeles" },
                { offset: -8, text: "(GMT -8:00) Pacific/Pitcairn" },
                { offset: -7, text: "(GMT -7:00) America/Phoenix" },
                { offset: -7, text: "(GMT -7:00) America/Denver" },
                { offset: -6, text: "(GMT -6:00) America/Guatemala" },
                { offset: -6, text: "(GMT -6:00) America/Chicago" },
                { offset: -6, text: "(GMT -6:00) Pacific/Easter" },
                { offset: -5, text: "(GMT -5:00) America/Bogota" },
                { offset: -5, text: "(GMT -5:00) America/New_York" },
                { offset: -4.5, text: "(GMT -4:30) America/Caracas" },
                { offset: -4, text: "(GMT -4:00) America/Halifax" },
                { offset: -4, text: "(GMT -4:00) America/Santo_Domingo" },
                { offset: -4, text: "(GMT -4:00) America/Asuncion" },
                { offset: -3.5, text: "(GMT -3:30) America/St_Johns" },
                { offset: -3, text: "(GMT -3:00) America/Godthab" },
                { offset: -3, text: "(GMT -3:00) America/Argentina/Buenos_Aires" },
                { offset: -3, text: "(GMT -3:00) America/Montevideo" },
                { offset: -2, text: "(GMT -2:00) America/Noronha" },
                { offset: -2, text: "(GMT -2:00) Etc/GMT+2" },
                { offset: -1, text: "(GMT -1:00) Atlantic/Azores" },
                { offset: -1, text: "(GMT -1:00) Atlantic/Cape_Verde" },
                { offset: 0, text: "(GMT 0:00) Etc/UTC" },
                { offset: 0, text: "(GMT 0:00) Europe/London" },
                { offset: 1, text: "(GMT +1:00) Europe/Berlin" },
                { offset: 1, text: "(GMT +1:00) Africa/Lagos" },
                { offset: 1, text: "(GMT +1:00) Africa/Windhoek" },
                { offset: 2, text: "(GMT +2:00) Asia/Beirut" },
                { offset: 2, text: "(GMT +2:00) Africa/Johannesburg" },
                { offset: 3, text: "(GMT +3:00) Europe/Moscow" },
                { offset: 3, text: "(GMT +3:00) Asia/Baghdad" },
                { offset: 3.5, text: "(GMT +3:30) Asia/Tehran" },
                { offset: 4, text: "(GMT +4:00) Asia/Dubai" },
                { offset: 4, text: "(GMT +4:00) Asia/Yerevan" },
                { offset: 4.5, text: "(GMT +4:30) Asia/Kabul" },
                { offset: 5, text: "(GMT +5:00) Asia/Yekaterinburg" },
                { offset: 5, text: "(GMT +5:00) Asia/Karachi" },
                { offset: 5.5, text: "(GMT +5:30) Asia/Kolkata" },
                { offset: 5.75, text: "(GMT +5:45) Asia/Kathmandu" },
                { offset: 6, text: "(GMT +6:00) Asia/Dhaka" },
                { offset: 6, text: "(GMT +6:00) Asia/Omsk" },
                { offset: 6.5, text: "(GMT +6:30) Asia/Rangoon" },
                { offset: 7, text: "(GMT +7:00) Asia/Krasnoyarsk" },
                { offset: 7, text: "(GMT +7:00) Asia/Jakarta" },
                { offset: 8, text: "(GMT +8:00) Asia/Shanghai" },
                { offset: 8, text: "(GMT +8:00) Asia/Irkutsk" },
                { offset: 8.75, text: "(GMT +8:45) Australia/Eucla" },
                { offset: 8.75, text: "(GMT +8:45) 'Australia/Eucla" },
                { offset: 9, text: "(GMT +9:00) Asia/Yakutsk" },
                { offset: 9, text: "(GMT +9:00) Asia/Tokyo" },
                { offset: 9.5, text: "(GMT +9:30) Australia/Darwin" },
                { offset: 9.5, text: "(GMT +9:30) Australia/Adelaide" },
                { offset: 10, text: "(GMT +10:00) Australia/Brisbane" },
                { offset: 10, text: "(GMT +10:00) Asia/Vladivostok" },
                { offset: 10, text: "(GMT +10:00) Australia/Sydney" },
                { offset: 10.5, text: "(GMT +10:30) Australia/Lord_Howe" },
                { offset: 11, text: "(GMT +11:00) Asia/Kamchatka" },
                { offset: 11, text: "(GMT +11:00) Pacific/Noumea" },
                { offset: 11.5, text: "(GMT +11:30) Pacific/Norfolk" },
                { offset: 12, text: "(GMT +12:00) Pacific/Auckland" },
                { offset: 12, text: "(GMT +12:00) Pacific/Tarawa" },
                { offset: 12.75, text: "(GMT +12:45) Pacific/Chatham" },
                { offset: 13, text: "(GMT +13:00) Pacific/Tongatapu" },
                { offset: 13, text: "(GMT +13:00) Pacific/Apia" },
                { offset: 14, text: "(GMT +14:00) Pacific/Kiritimati" }
            ];
        }
    }
}