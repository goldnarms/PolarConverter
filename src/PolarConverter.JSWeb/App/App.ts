/// <reference path="_all.ts" />
module PolarConverter {
    "use strict";

    angular.module("polarApp", ["blueimp.fileupload", "LocalStorageModule", "chieffancypants.loadingBar", "ngAnimate", "ajoslin.promise-tracker", "duScroll", "angulartics", "angulartics.google.analytics", "Scope.safeApply"])
        .config([
            "$httpProvider", "fileUploadProvider", "cfpLoadingBarProvider",
            ($httpProvider, fileUploadProvider, cfpLoadingBarProvider) => {
                $httpProvider.defaults.useXDomain = true;
                delete $httpProvider.defaults.headers.common["X-Requested-With"];
                fileUploadProvider.defaults.redirect = window.location.href.replace(
                    /\/[^\/]*$/,
                    "/cors/result.html?%s"
                    );
                angular.extend(fileUploadProvider.defaults, {
                    maxFileSize: 50000000,
                    acceptFileTypes: /(\.|\/)(hrm|xml|gpx)$/i
                });
                cfpLoadingBarProvider.includeSpinner = false;
            }])
        .controller("uploadCtrl", PolarConverter.UploadController.prototype.injection())
        .controller("fileDestroyCtrl", PolarConverter.FileDestroyController.prototype.injection())
        .controller("userfilesCtrl", PolarConverter.UserFilesController.prototype.injection())
        .controller("userProfileCtrl", PolarConverter.UserProfile.prototype.injection())
        .service("facebookShareService", PolarConverter.FacebookShareService.prototype.injection())
        .service("fileService", PolarConverter.FileService.prototype.injection())
        .service("userService", PolarConverter.UserService.prototype.injection())
        .service("common", PolarConverter.CommonService.prototype.injection())
        .directive("shareOnGooglePlus", PolarConverter.ShareOnGooglePlus.prototype.injection())
        .directive("shareOnTwitter", PolarConverter.ShareOnTwitter.prototype.injection())
        .directive("shareOnFacebook", PolarConverter.ShareOnFacebook.prototype.injection());
}