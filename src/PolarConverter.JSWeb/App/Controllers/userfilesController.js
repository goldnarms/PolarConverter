/// <reference path="../_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";

    var UserFilesController = (function () {
        function UserFilesController(common, fileService, cfpLoadingBar, userService) {
            this.common = common;
            this.fileService = fileService;
            this.cfpLoadingBar = cfpLoadingBar;
            this.userService = userService;
            //User = new <User>;
            //User.id = 1;
            this.init();
        }
        UserFilesController.prototype.injection = function () {
            return ["common", "fileService", "cfpLoadingBar", "userService", UserFilesController];
        };

        UserFilesController.prototype.exportToStrava = function (fileReference, fileName) {
            var _this = this;
            this.fileService.exportToService("Strava", fileReference).success(function () {
                _this.common.log.info("File exported to Strava");
            }).catch(function (error) {
                _this.common.log.error("Error: " + error);
            });
        };

        UserFilesController.prototype.init = function () {
            var _this = this;
            //this.fileList = [];
            this.cfpLoadingBar.start();
            this.userService.getUserId().then(function (userId) {
                _this.fileService.getFilesForUser(userId.data).then(function (data) {
                    _this.fileList = _.map(data.data, function (pf) {
                        return { name: pf.name, reference: pf.reference };
                    });
                    _this.cfpLoadingBar.complete();
                }).catch(function (error) {
                    _this.cfpLoadingBar.complete();
                    _this.common.log.error(error);
                });
            });
            //if (!!User) {
            //}
        };
        UserFilesController.$inject = ["common", "fileService", "cfpLoadingBar"];
        return UserFilesController;
    })();
    PolarConverter.UserFilesController = UserFilesController;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=userfilesController.js.map
