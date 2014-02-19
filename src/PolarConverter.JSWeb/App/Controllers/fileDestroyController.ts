/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";

    export interface IFileDestroyScope extends ng.IScope {
        file: any;
        clear: (file: any) => void;
    }

    export class FileDestroyController {
        public injection(): any[] {
            return ["$scope", "$http", FileDestroyController];
        }
        static $inject = ["$scope", "$http"];

        constructor(private $scope: IFileDestroyScope, private $http: ng.IHttpService) {
            var file = $scope.file,
                state;
            if (file.url) {
                file.$state = () => {
                    return state;
                };
                file.$destroy = () => {
                    state = "pending";
                    return $http({
                        url: file.deleteUrl,
                        method: file.deleteType
                    }).then(
                        () => {
                            state = "resolved";
                            $scope.clear(file);
                        },
                        () => {
                            state = "rejected";
                        }
                        );
                };
            } else if (!file.$cancel && !file._index) {
                file.$cancel = () => {
                    $scope.clear(file);
                };
            }
        }
    }
}