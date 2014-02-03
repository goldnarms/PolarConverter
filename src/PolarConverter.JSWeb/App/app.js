/// <reference path="_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    'use strict';

    angular.module("polarApp", ["blueimp.fileupload"]).config([
        '$httpProvider',
        'fileUploadProvider',
        function ($httpProvider, fileUploadProvider) {
            delete $httpProvider.defaults.headers.common['X-Requested-With'];
            fileUploadProvider.defaults.redirect = window.location.href.replace(/\/[^\/]*$/, '/cors/result.html?%s');
            angular.extend(fileUploadProvider.defaults, {
                maxFileSize: 50000000,
                acceptFileTypes: /(\.|\/)(hrm|xml|gpx)$/i
            });
        }
    ]).controller("uploadCtrl", PolarConverter.UploadController.prototype.injection()).controller("fileDestroyCtrl", PolarConverter.FileDestroyController.prototype.injection());
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=App.js.map
