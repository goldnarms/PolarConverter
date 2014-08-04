/// <reference path="../_All.ts" />

module PolarConverter {
    "use strict";
    export interface ICommonService {
        q: ng.IQService;
        log: ng.ILogService;
        timeout: ng.ITimeoutService;
        location: ng.ILocationService;
        loadingBar: ILoadingBar;
        containsString(textString: string, arg: string): boolean;
        stringFormat(args: string[]): string;
        escapeHtml(str: string): string;
        //now: () => Date;
        //today: () => Date;
    }
    export class CommonService implements ICommonService {
        static $inject = ["$q", "$log", "$timeout", "$location", "cfpLoadingBar"];
        public injection(): any[]{
            return ["$q", "$log", "$timeout", "$location", "cfpLoadingBar", CommonService];
        }

        constructor(public q: ng.IQService, public log: ng.ILogService, public timeout: ng.ITimeoutService, public location: ng.ILocationService, public loadingBar: ILoadingBar) {

        }

        public containsString(textString: string, arg: string): boolean {
            return textString.toString().toLowerCase().indexOf(arg.toString().toLowerCase()) !== -1;
        }

        public stringFormat(args: string[]): string {
            var s = args[0];
            for (var i = 0; i < args.length - 1; i++) {
                var reg = new RegExp("\\{" + i + "\\}", "gm");
                s = s.replace(reg, args[i + 1]);
            }
            return s;
        }

        //public now(): Date {
        //    return moment().utc().toDate();
        //}

        //public today(): Date {
        //    return moment().utc().startOf("day").toDate();
        //}

        public escapeHtml(str: string): string {
            /*Returns a string that can safely be placed into attributes and into elements
            without being interpreted as HTML by the browser. */
            return String(str)
                .replace(/&/g, "&amp;")
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#39;")
                .replace(/</g, "&lt;")
                .replace(/>/g, "&gt;");
        }
    }
}