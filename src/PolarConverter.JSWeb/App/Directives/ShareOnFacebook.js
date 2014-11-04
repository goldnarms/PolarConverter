/// <reference path="../_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";
    var ShareOnFacebook = (function () {
        function ShareOnFacebook($location) {
            var _this = this;
            this.$location = $location;
            this.restrict = "A";
            this.transclude = true;
            this.replace = true;
            this.template = this.getTemplate();
            this.scope = {
                fullFacebookUrl: "=",
                shareUrl: "@url",
                useCurrentUrl: "@" //Use this to share the current url with https://www.facebook.com/sharer/sharer.php
            };
            this.link = function (scope, element, attrs) { return _this.linkFn(scope, element, attrs); };
        }
        ShareOnFacebook.prototype.injection = function () {
            return ["$location", function ($location) {
                return new ShareOnFacebook($location);
            }];
        };
        ShareOnFacebook.prototype.linkFn = function (scope, element, attrs) {
            scope.$watch("fullFacebookUrl", function () {
                if (scope.fullFacebookUrl != null) {
                    scope.url = scope.fullFacebookUrl;
                }
            });
            if (scope.fullFacebookUrl) {
                scope.url = scope.fullFacebookUrl;
            }
            else {
                var url = "https://www.facebook.com/sharer/sharer.php";
                var parameters = this.getParameters(scope);
                scope.url = parameters === "" ? url : url + "?" + parameters;
            }
            element.bind("click", function (event) {
                window.open(scope.url, "facebook-share-dialog", "menubar=no,toolbar=no,resizable=yes,scrollbars=yes,status=no,width=626,height=436");
                event.preventDefault();
            });
        };
        ShareOnFacebook.prototype.getParameters = function (scope) {
            var parameters = "";
            if (scope.shareUrl) {
                parameters += "u=" + this.encode(scope.shareUrl);
            }
            if (!scope.shareUrl && scope.useCurrentUrl) {
                parameters += "u=" + this.encode(this.$location.absUrl());
            }
            return parameters;
        };
        ShareOnFacebook.prototype.encode = function (value) {
            return encodeURIComponent(value);
        };
        ShareOnFacebook.prototype.getTemplate = function () {
            return '<a href="{{url}}" target="_blank" data-ng-transclude=""></a>';
        };
        ShareOnFacebook.$inject = ["$location"];
        return ShareOnFacebook;
    })();
    PolarConverter.ShareOnFacebook = ShareOnFacebook;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=ShareOnFacebook.js.map