/// <reference path="../_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";

    var UploadController = (function () {
        function UploadController($scope, $http, $filter, $window, $document, common, storage, facebookShareService, userService) {
            this.$scope = $scope;
            this.$http = $http;
            this.$filter = $filter;
            this.$window = $window;
            this.$document = $document;
            this.common = common;
            this.storage = storage;
            this.facebookShareService = facebookShareService;
            this.userService = userService;
            this.initalized = false;
            this.showFileTable = true;
            this.init();
            this.setupWatches();
        }
        UploadController.prototype.injection = function () {
            return ["$scope", "$http", "$filter", "$window", "$document", "common", "localStorageService", "facebookShareService", "userService", UploadController];
        };

        UploadController.prototype.init = function () {
            var _this = this;
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
            this.uploadViewModel = { polarFiles: [], forceGarmin: false, gender: "m" };
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
            $.get("http://ipinfo.io", function (response) {
                _this.setWeightTypeBasedOnCountry(response.country);
                var loc = response.loc;
                var lat = loc.substring(0, loc.indexOf(","));
                var lng = loc.substring(loc.indexOf(",") + 1, loc.length);
                _this.setTimeZoneOffsetBasedOnCountry(lat, lng);
            }, "jsonp");

            if (this.initalized) {
                this.$http.get(url).then(function (response) {
                    _this.common.log.info(response);
                    _this.loadingFiles = false;
                    _this.queue = response.data.files || [];
                }, function () {
                    _this.loadingFiles = false;
                });
                this.initalized = true;
            }
            this.common.loadingBar.complete();
        };

        UploadController.prototype.callback = function (data) {
            this.common.log.info(data);
        };

        UploadController.prototype.shareToFacebook = function () {
            this.facebookShareService.openDialogue();
        };

        UploadController.prototype.onError = function (data) {
            this.common.log.error(data);
            this.common.loadingBar.complete();
        };

        UploadController.prototype.onUpload = function (data) {
            this.showExtraVariables = data.result.showExtraVariables;
            if (data.result.fileType === "gpx") {
                var gpxFile = { name: data.result.name, reference: data.result.reference, matched: false, version: data.result.gpxVersion };
                this.gpxFiles.push(gpxFile);
                var matchingPolarFile = this.checkForMatchingFile(this.uploadedFiles, gpxFile.name);
                if (matchingPolarFile) {
                    gpxFile.matched = true;
                    matchingPolarFile.gpxFile = gpxFile;
                }
            } else {
                if (data.result.weight) {
                    this.uploadViewModel.weight = data.result.weight;
                }
                var polarFile = { fileType: data.result.fileType, name: data.result.name, reference: data.result.reference, sport: data.result.sport, checked: true };
                this.uploadedFiles.push(polarFile);
                var matchingGpxFile = this.checkForMatchingFile(this.gpxFiles, polarFile.name);
                if (matchingGpxFile) {
                    polarFile.gpxFile = matchingGpxFile;
                    matchingGpxFile.matched = true;
                }
            }
            this.common.loadingBar.complete();
            this.showFileTable = false;
        };

        UploadController.prototype.setupWatches = function () {
            var _this = this;
            this.$scope.$on("fileuploadfail", function (event, data) {
                _this.onError(data);
            });
            this.$scope.$on("fileuploaddone", function (event, data) {
                _this.onUpload(data);
            });
        };

        UploadController.prototype.checkForMatchingFile = function (list, fileName) {
            return _.find(list, function (file) {
                return file.name.substring(0, file.name.length - 4) === fileName.substring(0, file.name.length - 4);
            });
        };

        UploadController.prototype.setWeightTypeBasedOnCountry = function (countryCode) {
            var imperialCountries = ["US", "GB", "LR", "MM"];
            this.isMetricWeight = !_.contains(imperialCountries, countryCode);
            this.uploadViewModel.weightMode = this.isMetricWeight ? "kg" : "lbs";
        };

        UploadController.prototype.setTimeZoneOffsetBasedOnCountry = function (lat, lng) {
            var _this = this;
            var tzDb = new TimeZoneDB;
            tzDb.getJSON({
                key: PolarConverter.Config.TimeZoneDBKey,
                lat: lat,
                lng: lng
            }, function (data) {
                var daylightSavings = data.dst;
                var timeZoneOffsetInHours = data.gmtOffset / 3600;
                if (daylightSavings === "1") {
                    timeZoneOffsetInHours--;
                }
                _this.selectedTimeZone = _.find(_this.timeZones, function (tz) {
                    return tz.offset === timeZoneOffsetInHours;
                });
                _this.$scope.$apply();
            });
        };

        UploadController.prototype.initPage = function () {
            this.reset();
            this.$scope.$broadcast("clearFiles");

            //var top = angular.element(document.getElementById('top'));
            this.$document.scrollTop(0, 1000);
        };

        UploadController.prototype.reset = function () {
            this.showFileTable = true;
            this.showUploadedFiles = true;
            this.gpxFiles = [];
            this.uploadedFiles = [];
            this.convertedFiles = [];
            this.errors = [];
            this.showErrors = false;
            this.common.loadingBar.complete();
        };
        UploadController.prototype.removeGpxFile = function (polarFile) {
            polarFile.gpxFile.matched = false;
            polarFile.gpxFile = null;
        };

        UploadController.prototype.setTimeZoneOffset = function (timeZone) {
            this.uploadViewModel.timeZoneOffset = timeZone.offset;
            this.storage.add("TimeZoneOffset", timeZone.offset);
        };

        UploadController.prototype.convert = function (uploadViewModel) {
            var _this = this;
            this.common.loadingBar.start();
            this.showUploadedFiles = false;
            this.isConverting = true;
            this.uploadViewModel.polarFiles = _.filter(this.uploadedFiles, function (uf) {
                return uf.checked;
            });
            this.uploadViewModel.timeZoneOffset = this.selectedTimeZone.offset;
            this.userService.getUserId().then(function (userId) {
                _this.uploadViewModel.uid = userId.data;
                _this.$http.post("/api/convert", _this.uploadViewModel, { tracker: "convertDone" }).then(function (response) {
                    _this.onSuccesssfullConvert(response);
                });
            });
        };

        UploadController.prototype.onSuccesssfullConvert = function (response) {
            if (response.data.ErrorMessages && response.data.ErrorMessages.length > 0) {
                this.errors = response.data.ErrorMessages;
                this.showErrors = true;
            }
            if (response.data.Reference != null) {
                this.convertedFiles.push({ name: response.data.FileName, reference: response.data.Reference });
            } else {
                this.showErrors = true;
            }
            this.isConverting = false;
            this.uploadedFiles = [];
            this.gpxFiles = [];
            this.$document.scrollTop(350, 1000);
            this.common.loadingBar.complete();
        };

        UploadController.prototype.setTimeZones = function () {
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
        };
        UploadController.$inject = ["$scope", "$http", "$filter", "$window", "$document", "common", "localStorageService", "facebookShareService", "userService"];
        return UploadController;
    })();
    PolarConverter.UploadController = UploadController;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=uploadController.js.map
