var PolarConverter;
(function (PolarConverter) {
    "use strict";

    var UserProfile = (function () {
        function UserProfile(common, userService) {
            this.common = common;
            this.userService = userService;
            this.init();
        }
        UserProfile.prototype.injection = function () {
            return ["common", "userService", UserProfile];
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
            throw new Error("Not implemented");
        };
        UserProfile.$inject = ["common", "userService"];
        return UserProfile;
    })();
    PolarConverter.UserProfile = UserProfile;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=userProfileController.js.map
