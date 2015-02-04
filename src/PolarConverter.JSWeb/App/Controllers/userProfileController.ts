module PolarConverter {
    "use strict";
    export interface IUserProfile {
        update(): void;
        userProfileForm: ng.IFormController;
        userViewModel: User;
    }

    export class UserProfile implements IUserProfile {
        static $inject = ["common", "userService", "$http"];
        public injection(): any[] {
            return ["common", "userService", "$http", UserProfile];
        }
        public userProfileForm: ng.IFormController;
        public userViewModel: UserViewModel;
        constructor(private common: ICommonService, private userService: IUserService, private $http: ng.IHttpService) {
            this.init();
        }

        public update(): void {
        }

        private reset(): void {
            this.userViewModel = null;
            this.userProfileForm.$setPristine();
        }

        private init(): void {
        }
    }
}                                                                      