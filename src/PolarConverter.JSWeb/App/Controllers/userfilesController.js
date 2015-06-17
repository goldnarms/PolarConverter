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
            this.init();
        }
        UserFilesController.prototype.injection = function () {
            return ["common", "fileService", "cfpLoadingBar", "userService", UserFilesController];
        };
        UserFilesController.prototype.exportToStrava = function (file) {
            var _this = this;
            this.fileService.exportToService("Strava", file.reference, file.name, this.userId, file.fromDropbox)
                .success(function () {
            })
                .catch(function (error) {
                _this.common.log.error("Error: " + error);
            });
        };
        UserFilesController.prototype.exportToRunkeeper = function (file) {
            var _this = this;
            this.fileService.exportToService("Runkeeper", file.reference, file.name, this.userId, file.fromDropbox)
                .success(function () {
            })
                .catch(function (error) {
                _this.common.log.error("Error: " + error);
            });
        };
        UserFilesController.prototype.init = function () {
            var _this = this;
            //this.fileList = [];
            this.cfpLoadingBar.start();
            this.userService.getUserId().then(function (userId) {
                _this.userId = userId.data;
                _this.fileService.getFilesForUser(userId.data).then(function (data) {
                    _this.fileList = _.map(data.data, function (pf) {
                        return { name: pf.name, reference: pf.reference };
                    });
                    _this.cfpLoadingBar.complete();
                })
                    .catch(function (error) {
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