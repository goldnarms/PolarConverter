var PolarConverter;
(function (PolarConverter) {
    "use strict";
    var UserProfile = (function () {
        function UserProfile(common, userService, $http) {
            this.common = common;
            this.userService = userService;
            this.$http = $http;
            this.init();
        }
        UserProfile.prototype.injection = function () {
            return ["common", "userService", "$http", UserProfile];
        };
        UserProfile.prototype.connectToStrava = function () {
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
        };
        UserProfile.prototype.update = function () {
            this.common.loadingBar.start();
            var userId = 1;
            this.userService.updateProfile(userId, this.userViewModel);
        };
        UserProfile.prototype.reset = function () {
            this.userViewModel = null;
            this.userProfileForm.$setPristine();
        };
        UserProfile.prototype.init = function () {
            console.log("UserProfile");
        };
        UserProfile.$inject = ["common", "userService", "$http"];
        return UserProfile;
    })();
    PolarConverter.UserProfile = UserProfile;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=userProfileController.js.map