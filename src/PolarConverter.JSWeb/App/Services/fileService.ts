module PolarConverter {
    "use strict";
    export interface IFileService {
        getFilesForUser(userId: number): ng.IHttpPromise<any>;
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
    }
}