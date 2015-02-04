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
        UserProfile.prototype.update = function () {
        };
        UserProfile.prototype.reset = function () {
            this.userViewModel = null;
            this.userProfileForm.$setPristine();
        };
        UserProfile.prototype.init = function () {
        };
        UserProfile.$inject = ["common", "userService", "$http"];
        return UserProfile;
    })();
    PolarConverter.UserProfile = UserProfile;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=userProfileController.js.map