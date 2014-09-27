module PolarConverter {
    "use strict";
    export interface IUserProfile {
        update(): void;
        userProfileForm: ng.IFormController;
        userViewModel: User;
        connectToStrava():void;
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

        public connectToStrava(): void {
            console.log("Connecting to strava");
            //this.$http.get("https://www.strava.com/oauth/authorize?client_id=2995&response_type=code&redirect_uri=http://localhost:50713/Services/ExternalLoginResult&scope=write&state=mystate&approval_prompt = force");
            //this.$http.post("https://www.strava.com/oauth/token", {
            //    client_id: "2995",
            //    client_secret: "1210fbbd67f5e9b2f4978f3860b9634504035b3a",
            //    code: "7619b27c962ea79b8de2964162ee65dd"
            //});
            this.$http({
                url: "https://www.strava.com/oauth/token",
                method: "POST",
                data: JSON.stringify({
                    client_id: "2995",
                    client_secret: "1210fbbd67f5e9b2f4978f3860b9634504035b3a",
                    code: "7619b27c962ea79b8de2964162ee65dd"
                }),
                withCredentials: false
            });
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
            console.log("UserProfile");
        }
    }
}                                                                      