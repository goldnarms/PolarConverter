module PolarConverter {
    "use strict";
    export interface IUserProfile {
        update(): void;
        userProfileForm: ng.IFormController;
        userViewModel: User;
    }

    export class UserProfile implements IUserProfile {
        static $inject = ["common", "userService"];
        public injection(): any[] {
            return ["common", "userService", UserProfile];
        }
        public userProfileForm: ng.IFormController;
        public userViewModel: UserViewModel;
        constructor(private common: ICommonService, private userService: IUserService) {
            this.init();
        }

        public update(): void {
            this.common.loadingBar.start();
            var userId = 1;
            this.userService.updateProfile(userId, this.userViewModel);
        }

        private reset(): void {
            this.userViewModel = null;
            this.userProfileForm.$setPristine();
        }

        private init(): void {
            throw new Error("Not implemented");
        }
    }
}                                                                      