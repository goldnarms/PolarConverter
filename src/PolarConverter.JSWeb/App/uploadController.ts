/// <reference path="_all.ts" />
module PolarConverter {
    'use strict';

    export class UploadController {
        public injection(): any[] { return ["$scope", "$http", "$filter", "$window", UploadController]; }
        static $inject = ["$scope", "$http", "$filter", "$window"];
        public options: any;
        public loadingFiles: boolean;
        public queue: any[];
        public uploadedFiles: PolarConverter.PolarFile[];

        constructor(private $scope: ng.IScope, private $http: ng.IHttpService, private $filter: ng.IFilterService, private $window: ng.IWindowService, private $log: ng.ILogService) {
            this.uploadedFiles = [];
            var url = "/api/upload";
            this.options = {
                acceptFileTypes: /(\.|\/)(gpx|hrm|xml)$/i,
                url: url,
                dataType: 'json'
            };
            this.loadingFiles = true;
            this.$http.get(url)
                .then(
                (response) => {
                    this.$log.info(response);
                    this.loadingFiles = false;
                    this.queue = response.data.files || [];
                },
                () => {
                    this.loadingFiles = false;
                }
                );

            this.$scope.$on('fileuploadfail', (event, data) => {
                this.handleError(data);
            });
            this.$scope.$on('fileuploaddone', (event, data) => {
                this.handleUpload(data);
            });
        }

        private handleError(data: any): void {
            this.$log.error(data);
        }

        private handleUpload(data: any): void {
            this.uploadedFiles.push(<PolarConverter.PolarFile>{ fileType: data.result.fileType, name: data.result.name, reference: data.result.reference });
        }
    }
}