module PolarConverter {
    "use strict";

    export interface IUserService {
        updateProfile(userId: number, user: User): void;
    }

    export class UserService implements IUserService {
        static $inject = ["$http", "$log"];
        public injection(): any[] {
            return ["$http", "$log", UserService];
        }

        constructor($http: ng.IHttpService, $log: ng.ILogService) {
            
        }

        public updateProfile(userId: number, user: User): void {
            
        }
    }
}