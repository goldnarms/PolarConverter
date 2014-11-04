/// <reference path="../_All.ts" />
var PolarConverter;
(function (PolarConverter) {
    "use strict";
    var CommonService = (function () {
        function CommonService(q, log, timeout, location, loadingBar) {
            this.q = q;
            this.log = log;
            this.timeout = timeout;
            this.location = location;
            this.loadingBar = loadingBar;
        }
        CommonService.prototype.injection = function () {
            return ["$q", "$log", "$timeout", "$location", "cfpLoadingBar", CommonService];
        };
        CommonService.prototype.containsString = function (textString, arg) {
            return textString.toString().toLowerCase().indexOf(arg.toString().toLowerCase()) !== -1;
        };
        CommonService.prototype.stringFormat = function (args) {
            var s = args[0];
            for (var i = 0; i < args.length - 1; i++) {
                var reg = new RegExp("\\{" + i + "\\}", "gm");
                s = s.replace(reg, args[i + 1]);
            }
            return s;
        };
        //public now(): Date {
        //    return moment().utc().toDate();
        //}
        //public today(): Date {
        //    return moment().utc().startOf("day").toDate();
        //}
        CommonService.prototype.escapeHtml = function (str) {
            /*Returns a string that can safely be placed into attributes and into elements
            without being interpreted as HTML by the browser. */
            return String(str).replace(/&/g, "&amp;").replace(/"/g, "&quot;").replace(/'/g, "&#39;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        };
        CommonService.$inject = ["$q", "$log", "$timeout", "$location", "cfpLoadingBar"];
        return CommonService;
    })();
    PolarConverter.CommonService = CommonService;
})(PolarConverter || (PolarConverter = {}));
//# sourceMappingURL=Common.js.map