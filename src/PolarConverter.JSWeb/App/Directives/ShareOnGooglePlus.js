/// <reference path="../_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";
    var ShareOnGooglePlus = (function () {
        function ShareOnGooglePlus($location) {
            var _this = this;
            this.$location = $location;
            this.restrict = "A";
            this.transclude = true;
            this.replace = true;
            this.template = this.getTemplate();
            this.scope = {
                shareUrl: "@url",
                useCurrentUrl: "@"
            };
            this.link = function (scope, element, attrs) { return _this.linkFn(scope, element, attrs); };
        }
        ShareOnGooglePlus.prototype.injection = function () {
            return ["$location", function ($location) {
                return new ShareOnGooglePlus($location);
            }];
        };
        ShareOnGooglePlus.prototype.linkFn = function (scope, element, attrs) {
            var url = "https://plus.google.com/share";
            var parameters = this.getParameters(scope);
            scope.url = parameters === "" ? url : url + "?" + parameters;
            element.bind("click", function (event) {
                window.open(scope.url, "google-plus-share-dialog", "menubar=no,toolbar=no,resizable=yes,scrollbars=yes,status=no,width=600,height=600");
                event.preventDefault();
            });
        };
        ShareOnGooglePlus.prototype.getParameters = function (scope) {
            var parameters = "";
            if (scope.shareUrl) {
                parameters += "url=" + this.encode(scope.shareUrl);
            }
            if (!scope.shareUrl && scope.useCurrentUrl) {
                parameters += "url=" + this.encode(this.$location.absUrl());
            }
            return parameters;
        };
        ShareOnGooglePlus.prototype.encode = function (value) {
            return encodeURIComponent(value);
        };
        ShareOnGooglePlus.prototype.getTemplate = function () {
            return '<a href="{{url}}" target="_blank" data-ng-transclude=""></a>';
        };
        ShareOnGooglePlus.$inject = ["$location"];
        return ShareOnGooglePlus;
    })();
    PolarConverter.ShareOnGooglePlus = ShareOnGooglePlus;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=ShareOnGooglePlus.js.map