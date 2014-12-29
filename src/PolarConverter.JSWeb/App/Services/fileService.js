var PolarConverter;
(function (PolarConverter) {
    "use strict";
    var FileService = (function () {
        function FileService($http, $log, $q) {
            this.$http = $http;
            this.$log = $log;
            this.$q = $q;
        }
        FileService.prototype.injection = function () {
            return ["$http", "$log", "$q", FileService];
        };
        FileService.prototype.getFilesForUser = function (userId) {
            return this.$http.get("/api/file?id=" + userId);
        };
        FileService.prototype.getDropboxFilesForUser = function (userId) {
            return this.$http.get("/api/service/getFilesFromDropbox?id=" + userId);
        };
        FileService.prototype.exportToService = function (provider, fileReference, fileName, userId, fromDropbox) {
            console.log(fileReference);
            var exportData = { provider: provider, reference: fileReference, name: fileName, userId: userId, fromDropbox: fromDropbox };
            return this.$http.post("/api/service/export/", exportData);
        };
        FileService.$inject = ["$http", "$log", "$q"];
        return FileService;
    })();
    PolarConverter.FileService = FileService;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=fileService.js.map