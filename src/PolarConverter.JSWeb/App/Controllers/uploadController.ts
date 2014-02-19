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
        checkForMatchingFile(list: PolarConverter.File[], fileName: string): PolarConverter.File;
    }

    export class UploadController {
        public injection(): any[] { return ["$scope", "$http", "$filter", "$window", UploadController]; }
        static $inject = ["$scope", "$http", "$filter", "$window"];
        public options: any;
        public loadingFiles: boolean;
        public queue: any[];
        public uploadedFiles: PolarConverter.PolarFile[];
        public gpxFiles: PolarConverter.GpxFile[];

        constructor(private $scope: ng.IScope, private $http: ng.IHttpService, private $filter: ng.IFilterService, private $window: ng.IWindowService, private $log: ng.ILogService) {
            this.init();
            this.setupWatches();
        }

        private init(): void {
            this.uploadedFiles = [];
            this.gpxFiles = [];
            var url = "/api/upload";
            this.options = {
                acceptFileTypes: /(\.|\/)(gpx|hrm|xml)$/i,
                url: url,
                dataType: "json"
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
                });
        }

        private handleError(data: any): void {
            this.$log.error(data);
        }

        private handleUpload(data: any): void {
            if (data.result.fileType === 2) {
                var gpxFile = <PolarConverter.GpxFile>{ name: data.result.name, matched: false };
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
                this.handleError(data);
            });
            this.$scope.$on("fileuploaddone", (event, data) => {
                this.handleUpload(data);
            });
        }

        public checkForMatchingFile(list: PolarConverter.File[], fileName: string): PolarConverter.File {
            return _.find(list, (file) => {
                return file.name.substring(0, file.name.length - 4) === fileName.substring(0, file.name.length - 4);
            });
        }
    }
}