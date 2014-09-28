module PolarConverter {
    "use strict";
    export interface IFileService {
        getFilesForUser(userId: number): ng.IHttpPromise<any>;
        exportToService(provider: string, fileReference: string): ng.IHttpPromise<any>;
    }

    export class FileService implements IFileService {
        public injection(): any[] {
            return ["$http", "$log", "$q", FileService];
        }
        static $inject = ["$http", "$log", "$q"];

        constructor(private $http: ng.IHttpService, private $log: ng.ILogService, private $q: ng.IQService) {
            
        }

        public getFilesForUser(userId: number): ng.IHttpPromise<any> {
            return this.$http.get("/api/file?id=" + userId);
        }

        public exportToService(provider: string, fileReference: string): ng.IHttpPromise<any> {
            var exportData = { provider: provider, fileReference: fileReference };
            return this.$http.post("/api/service/post/", exportData);
        }
    }
}