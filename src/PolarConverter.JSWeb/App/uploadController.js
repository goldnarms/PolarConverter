/// <reference path="_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";

    var UploadController = (function () {
        function UploadController($scope, $http, $filter, $window, $log) {
            this.$scope = $scope;
            this.$http = $http;
            this.$filter = $filter;
            this.$window = $window;
            this.$log = $log;
            this.init();
            this.setupWatches();
        }
        UploadController.prototype.injection = function () {
            return ["$scope", "$http", "$filter", "$window", UploadController];
        };

        UploadController.prototype.init = function () {
            var _this = this;
            this.uploadedFiles = [];
            var url = "/api/upload";
            this.options = {
                acceptFileTypes: /(\.|\/)(gpx|hrm|xml)$/i,
                url: url,
                dataType: "json"
            };
            this.loadingFiles = true;
            this.$http.get(url).then(function (response) {
                _this.$log.info(response);
                _this.loadingFiles = false;
                _this.queue = response.data.files || [];
            }, function () {
                _this.loadingFiles = false;
            });
        };

        UploadController.prototype.handleError = function (data) {
            this.$log.error(data);
        };

        UploadController.prototype.handleUpload = function (data) {
            this.uploadedFiles.push({ fileType: data.result.fileType, name: data.result.name, reference: data.result.reference, sport: data.result.sport, checked: true });
        };

        UploadController.prototype.setupWatches = function () {
            var _this = this;
            this.$scope.$on("fileuploadfail", function (event, data) {
                _this.handleError(data);
            });
            this.$scope.$on("fileuploaddone", function (event, data) {
                _this.handleUpload(data);
            });
        };
        UploadController.$inject = ["$scope", "$http", "$filter", "$window"];
        return UploadController;
    })();
    PolarConverter.UploadController = UploadController;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=uploadController.js.map
