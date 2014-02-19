/// <reference path="../_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";

    var FileDestroyController = (function () {
        function FileDestroyController($scope, $http) {
            this.$scope = $scope;
            this.$http = $http;
            var file = $scope.file, state;
            if (file.url) {
                file.$state = function () {
                    return state;
                };
                file.$destroy = function () {
                    state = "pending";
                    return $http({
                        url: file.deleteUrl,
                        method: file.deleteType
                    }).then(function () {
                        state = "resolved";
                        $scope.clear(file);
                    }, function () {
                        state = "rejected";
                    });
                };
            } else if (!file.$cancel && !file._index) {
                file.$cancel = function () {
                    $scope.clear(file);
                };
            }
        }
        FileDestroyController.prototype.injection = function () {
            return ["$scope", "$http", FileDestroyController];
        };
        FileDestroyController.$inject = ["$scope", "$http"];
        return FileDestroyController;
    })();
    PolarConverter.FileDestroyController = FileDestroyController;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=fileDestroyController.js.map
