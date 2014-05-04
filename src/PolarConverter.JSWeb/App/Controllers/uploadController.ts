/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";
    export interface IUploadController {
        injection(): any[];
        options: any;
        loadingFiles: boolean;
        queue: any[];
        uploadedFiles: PolarConverter.PolarFile[];
        gpxFiles: PolarConverter.GpxFile[];
        convertedFiles: PolarConverter.File[];
        sports: any[];
        isMetricWeight: boolean;
        timeZones: PolarConverter.TimeZone[];
        uploadViewModel: PolarConverter.UploadViewModel;
        checkForMatchingFile(list: PolarConverter.File[], fileName: string): PolarConverter.File;
        setWeightTypeBasedOnCountry(countryCode: string): void;
        setTimeZoneOffset(timeZone: PolarConverter.TimeZone): void;
        reset(): void;
        convert(uploadViewModel: PolarConverter.UploadViewModel): void;
        removeGpxFile(polarFile: PolarConverter.PolarFile): void;
        isConverting: boolean;
        showExtraVariables: boolean;
    }

    export class UploadController {
        public injection(): any[] { return ["$scope", "$http", "$filter", "$window", "$log", "localStorageService", UploadController]; }
        static $inject = ["$scope", "$http", "$filter", "$window", "$log", "localStorageService"];
        public options: any;
        public loadingFiles: boolean;
        public queue: any[];
        public uploadedFiles: PolarConverter.PolarFile[];
        public gpxFiles: PolarConverter.GpxFile[];
        public convertedFiles: PolarConverter.File[];
        public uploadViewModel: PolarConverter.UploadViewModel;
        public isMetricWeight: boolean;
        public isConverting: boolean;
        public showExtraVariables: boolean;
        public timeZones: PolarConverter.TimeZone[];
        public sports: any[];
        public errors: string[];

        constructor(private $scope: ng.IScope, private $http: ng.IHttpService, private $filter: ng.IFilterService, private $window: ng.IWindowService, private $log: ng.ILogService, private storage: PolarConverter.IStorage) {
            this.init();
            this.setupWatches();
        }

        private init(): void {
            this.setTimeZones();
            this.uploadedFiles = [];
            this.convertedFiles = [];
            this.gpxFiles = [];
            this.sports = [];
            this.errors = [];
            var initalized = false;
            for (var sport in PolarConverter.sportEnum) {
                if (typeof PolarConverter.sportEnum[sport] === "number") {
                    this.sports.push(sport);
                }
            }

            this.isMetricWeight = true;
            this.isConverting = false;
            this.uploadViewModel = { weightMode: "kg", weight: 0, timeZoneOffset: -12, polarFiles: [], forceGarmin: false, gender: "m", age: 0 };
            var url = "/api/upload";
            this.options = {
                autoUpload: true,
                acceptFileTypes: /(\.|\/)(gpx|hrm|xml)$/i,
                url: url,
                dataType: "json"
            };
            this.loadingFiles = true;
            this.$http.jsonp("http://ipinfo.io", (response) => {
                this.setWeightTypeBasedOnCountry(response.country);
            });
            if (initalized) {
                this.$http.get(url)
                    .then(
                    (response) => {
                        this.$log.info(response);
                        this.loadingFiles = false;
                        this.queue = response.data.files || [];
                    },
                    () => {
                        this.loadingFiles = false;
                    });
            }

            initalized = true;
        }

        private onError(data: any): void {
            this.$log.error(data);
        }

        private onUpload(data: any): void {
            this.showExtraVariables = data.result.showExtraVariables;
            this.uploadViewModel.weight = data.result.weight;
            if (data.result.fileType === "gpx") {
                var gpxFile = <PolarConverter.GpxFile>{ name: data.result.name, reference: data.result.reference, matched: false, version: data.result.gpxVersion };
                this.gpxFiles.push(gpxFile);
                var matchingPolarFile = <PolarConverter.PolarFile> this.checkForMatchingFile(this.uploadedFiles, gpxFile.name);
                if (matchingPolarFile) {
                    gpxFile.matched = true;
                    matchingPolarFile.gpxFile = gpxFile;
                }
            } else {
                var polarFile = <PolarConverter.PolarFile>{ fileType: data.result.fileType, name: data.result.name, reference: data.result.reference, sport: data.result.sport, checked: true };
                this.uploadedFiles.push(polarFile);
                var matchingGpxFile = <PolarConverter.GpxFile> this.checkForMatchingFile(this.gpxFiles, polarFile.name);
                if (matchingGpxFile) {
                    polarFile.gpxFile = matchingGpxFile;
                    matchingGpxFile.matched = true;
                }
            }
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

        public setWeightTypeBasedOnCountry(countryCode: string) {
            var imperialCountries = ["US", "GB", "LR", "MM"];
            this.isMetricWeight = !_.contains(imperialCountries, countryCode);
            this.uploadViewModel.weightMode = this.isMetricWeight ? "kg" : "lbs";
        }

        public reset(): void {
            this.gpxFiles = [];
            this.uploadedFiles = [];
            this.convertedFiles = [];
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
            this.isConverting = true;
            this.uploadViewModel.polarFiles = _.filter(this.uploadedFiles, (uf: PolarConverter.PolarFile) => { return uf.checked; });
            this.$http.post("/api/convert", this.uploadViewModel, { tracker: "convertDone"}).then((response) => {
                this.onSuccesssfullConvert(response);
            });
        }

        private onSuccesssfullConvert(response): void {
            if (response.data.ErrorMessages && response.data.ErrorMessages.length > 0) {
                this.errors = response.data.ErrorMessages;
            }
            this.convertedFiles.push(<PolarConverter.File>{ name: response.data.FileName, reference: response.data.Reference });
            this.isConverting = false;
            this.uploadedFiles = [];
            this.gpxFiles = [];
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