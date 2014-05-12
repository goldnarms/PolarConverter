/// <reference path="../App.ts" />

module PolarConverter {
    "use strict";
    export interface IFacebookShareService {
        openDialogue() :string;
    }
    export class FacebookShareService implements IFacebookShareService {
        public injection(): any[] { return [FacebookShareService]; }
        static $inject = [];

        constructor() {
        }

        openDialogue(): string {
            return this.facebookShareUrl({
                "name": "Test",
                "caption": "Caption",
                "description": "Description",
                "picture": "",
                "link": ""
            });
        }

        facebookShareUrl(params: any): any {
            return "https://www.facebook.com/dialog/feed?" + $.param($.extend({}, {
                "app_id": PolarConverter.Config.FacebookId,
                "display": "popup",
                "redirect_uri": "http://www.polarconverter.com"
            }, params));
        }
    }
}