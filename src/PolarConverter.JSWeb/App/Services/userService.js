var PolarConverter;
(function (PolarConverter) {
    "use strict";

    var UserService = (function () {
        function UserService($http, $log) {
        }
        UserService.prototype.injection = function () {
            return ["$http", "$log", UserService];
        };

        UserService.prototype.updateProfile = function (userId, user) {
        };
        UserService.$inject = ["$http", "$log"];
        return UserService;
    })();
    PolarConverter.UserService = UserService;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=userService.js.map
