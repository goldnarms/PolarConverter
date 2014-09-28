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

        FileService.prototype.exportToService = function (provider, fileReference) {
            var exportData = { provider: provider, fileReference: fileReference };
            return this.$http.post("/api/service/post/", exportData);
        };
        FileService.$inject = ["$http", "$log", "$q"];
        return FileService;
    })();
    PolarConverter.FileService = FileService;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=fileService.js.map
