/// <reference path="../_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";

    var UserFilesController = (function () {
        function UserFilesController(common, fileService, cfpLoadingBar) {
            this.common = common;
            this.fileService = fileService;
            this.cfpLoadingBar = cfpLoadingBar;
            //User = new <User>;
            //User.id = 1;
            this.init();
        }
        UserFilesController.prototype.injection = function () {
            return ["common", "fileService", "cfpLoadingBar", UserFilesController];
        };

        UserFilesController.prototype.exportToStrava = function (fileRef) {
        };

        UserFilesController.prototype.init = function () {
            var _this = this;
            //this.fileList = [];
            this.cfpLoadingBar.start();
            this.fileService.getFilesForUser(1).then(function (data) {
                _this.fileList = _.map(data.data, function (pf) {
                    return { name: pf.Name, reference: pf.Reference };
                });
                _this.cfpLoadingBar.complete();
            }).catch(function (error) {
                _this.cfpLoadingBar.complete();
                _this.common.log.error(error);
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
