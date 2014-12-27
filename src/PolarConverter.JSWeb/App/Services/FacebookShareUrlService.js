/// <reference path="../App.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";
    var FacebookShareService = (function () {
        function FacebookShareService() {
        }
        FacebookShareService.prototype.injection = function () {
            return [FacebookShareService];
        };
        FacebookShareService.prototype.openDialogue = function () {
            return this.facebookShareUrl({
                "name": "PolarConverter",
                "caption": "Spread the word",
                "description": "Convert your Polar files with PolarConverter",
                "picture": "",
                "link": ""
            });
        };
        FacebookShareService.prototype.facebookShareUrl = function (params) {
            return "https://www.facebook.com/dialog/feed?" + $.param($.extend({}, {
                "app_id": PolarConverter.Config.FacebookId,
                "display": "popup",
                "redirect_uri": "http://www.polarconverter.com"
            }, params));
        };
        FacebookShareService.$inject = [];
        return FacebookShareService;
    })();
    PolarConverter.FacebookShareService = FacebookShareService;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=FacebookShareUrlService.js.map