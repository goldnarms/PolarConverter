/// <reference path="../_all.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";
    var ShareOnTwitter = (function () {
        function ShareOnTwitter($location) {
            var _this = this;
            this.$location = $location;
            this.restrict = "A";
            this.transclude = true;
            this.replace = true;
            this.template = this.getTemplate();
            this.scope = {
                tweetUrl: "@url",
                tweetText: "=text",
                tweetVia: "@via",
                tweetRelated: "@related",
                useCurrentUrl: "@"
            };
            this.link = function (scope, element, attrs) { return _this.linkFn(scope, element, attrs); };
        }
        ShareOnTwitter.prototype.injection = function () {
            return ["$location", function ($location) { return new ShareOnTwitter($location); }];
        };
        ShareOnTwitter.prototype.linkFn = function (scope, element, attrs) {
            var _this = this;
            scope.$watch("tweetText", function () {
                var url = "https://twitter.com/share";
                var parameters = _this.getParameters(scope);
                scope.url = parameters === "" ? url : url + "?" + parameters;
            });
            element.bind("click", function (event) {
                window.open(scope.url, "twitter-share-dialog", "menubar=no,toolbar=no,resizable=yes,scrollbars=yes,status=no,width=550,height=450");
                event.preventDefault();
            });
        };
        ShareOnTwitter.prototype.getParameters = function (scope) {
            var parameters = [];
            if (scope.tweetVia) {
                parameters.push("via=" + this.encode(scope.tweetVia));
            }
            if (scope.tweetText) {
                parameters.push("text=" + this.encode(scope.tweetText));
            }
            if (scope.tweetRelated) {
                parameters.push("related=" + this.encode(scope.tweetRelated));
            }
            if (scope.tweetUrl) {
                parameters.push("url=" + this.encode(scope.tweetUrl));
            }
            if (!scope.tweetUrl && scope.useCurrentUrl) {
                parameters.push("url=" + this.encode(this.$location.absUrl()));
            }
            return parameters.join("&");
        };
        ShareOnTwitter.prototype.encode = function (value) {
            return encodeURIComponent(value);
        };
        ShareOnTwitter.prototype.getTemplate = function () {
            return '<a data-ng-href="{{url}}" target="_blank" data-ng-transclude=""></a>';
        };
        ShareOnTwitter.$inject = ["$location"];
        return ShareOnTwitter;
    })();
    PolarConverter.ShareOnTwitter = ShareOnTwitter;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=ShareOnTwitter.js.map