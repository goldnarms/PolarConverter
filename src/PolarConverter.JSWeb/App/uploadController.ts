module PolarConverter {
    'use strict';
    export interface IUploadScope extends ng.IScope {
        options: any;
        loadingFiles: boolean;
        queue: any[];
    }

    export class UploadController {
        public injection(): any[] { return ["$scope", "$http", "$filter", "$window", UploadController]; }
        static $inject = ["$scope", "$http", "$filter", "$window"];

        constructor(private $scope: IUploadScope, private $http: ng.IHttpService, private $filter: ng.IFilterService, private $window: ng.IWindowService) {
            var url = "/Backload/UploadHandler";
            this.$scope.options = {
                url: url
            };
            $scope.loadingFiles = true;
            $http.get(url)
                .then(
                (response) => {
                    $scope.loadingFiles = false;
                    $scope.queue = response.data.files || [];
                },
                () => {
                    $scope.loadingFiles = false;
                }
                );
        }
    }
}