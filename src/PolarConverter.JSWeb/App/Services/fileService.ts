module PolarConverter {
    "use strict";
    export interface IFileService {
        getFilesForUser(userId: string): ng.IHttpPromise<any>;
        exportToService(provider: string, fileReference: string, fileName: string, userId: string, fromDropbox: boolean): ng.IHttpPromise<any>;
        getDropboxFilesForUser(userId: string): ng.IHttpPromise<any>;
    }

    export class FileService implements IFileService {
        public injection(): any[] {
            return ["$http", "$log", "$q", FileService];
        }
        static $inject = ["$http", "$log", "$q"];

        constructor(private $http: ng.IHttpService, private $log: ng.ILogService, private $q: ng.IQService) {
            
        }

        public getFilesForUser(userId: string): ng.IHttpPromise<any> {
            return this.$http.get("/api/file?id=" + userId);
        }

        public getDropboxFilesForUser(userId: string): ng.IHttpPromise<any> {
            return this.$http.get("/api/service/getFilesFromDropbox?id=" + userId);
        }

        public exportToService(provider: string, fileReference: string, fileName: string, userId: string, fromDropbox: boolean): ng.IHttpPromise<any> {
            console.log(fileReference);
            var exportData = { provider: provider, reference: fileReference, name: fileName, userId: userId, fromDropbox: fromDropbox };
            return this.$http.post("/api/service/export/", exportData);
        }
    }
}