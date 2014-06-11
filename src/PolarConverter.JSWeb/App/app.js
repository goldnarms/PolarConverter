/// <reference path="_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";

    angular.module("polarApp", ["blueimp.fileupload", "LocalStorageModule", "chieffancypants.loadingBar", "ngAnimate", "ajoslin.promise-tracker", "duScroll"]).config([
        "$httpProvider", "fileUploadProvider", "cfpLoadingBarProvider",
        function ($httpProvider, fileUploadProvider, cfpLoadingBarProvider) {
            delete $httpProvider.defaults.headers.common["X-Requested-With"];
            fileUploadProvider.defaults.redirect = window.location.href.replace(/\/[^\/]*$/, "/cors/result.html?%s");
            angular.extend(fileUploadProvider.defaults, {
                maxFileSize: 50000000,
                acceptFileTypes: /(\.|\/)(hrm|xml|gpx)$/i
            });
            cfpLoadingBarProvider.includeSpinner = false;
        }]).controller("uploadCtrl", PolarConverter.UploadController.prototype.injection()).controller("fileDestroyCtrl", PolarConverter.FileDestroyController.prototype.injection()).service("facebookShareService", PolarConverter.FacebookShareService.prototype.injection()).directive("shareOnGooglePlus", PolarConverter.ShareOnGooglePlus.prototype.injection()).directive("shareOnTwitter", PolarConverter.ShareOnTwitter.prototype.injection()).directive("shareOnFacebook", PolarConverter.ShareOnFacebook.prototype.injection());
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=app.js.map
