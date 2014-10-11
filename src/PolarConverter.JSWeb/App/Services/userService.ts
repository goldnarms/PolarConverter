module PolarConverter {
    "use strict";

    export interface IUserService {
        updateProfile(userId: number, user: User): void;
        getUserId(): ng.IHttpPromise<string>;
    }

    export class UserService implements IUserService {
        static $inject = ["$http", "$log"];
        public injection(): any[] {
            return ["$http", "$log", UserService];
        }

        constructor(private $http: ng.IHttpService, private $log: ng.ILogService) {
            
        }

        public updateProfile(userId: number, user: User): void {
            
        }

        public getUserId(): ng.IHttpPromise<string> {
            return this.$http.get("/account/CurrentUserId");
        }
    }
}