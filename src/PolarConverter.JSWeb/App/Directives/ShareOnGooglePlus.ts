/// <reference path="../_all.ts" />

module PolarConverter {
    "use strict";

    export class ShareOnGooglePlus {
        static $inject = ["$location"];
        public injection(): any[] {
            return ["$location", ($location) => { return new ShareOnGooglePlus($location); }];
        }

        public restrict: string;
        public transclude: boolean;
        public replace: boolean;
        public template: string;
        public scope: any;
        public link: (scope: ShareOnGooglePlusScope, element: JQuery, attrs: ng.IAttributes) => void;

        constructor(private $location: ng.ILocationService) {
            this.restrict = "A";
            this.transclude = true;
            this.replace = true;
            this.template = this.getTemplate();
            this.scope = {
                shareUrl: "@url",
                useCurrentUrl: "@"
            };
            this.link = (scope, element, attrs) => this.linkFn(scope, element, attrs);
        }

        linkFn(scope: ShareOnGooglePlusScope, element: JQuery, attrs: ng.IAttributes) {
            var url = "https://plus.google.com/share";
            var parameters = this.getParameters(scope);
            scope.url = parameters === "" ? url : url + "?" + parameters;

            element.bind("click", (event) => {
                window.open(scope.url, "google-plus-share-dialog", "menubar=no,toolbar=no,resizable=yes,scrollbars=yes,status=no,width=600,height=600");
                event.preventDefault();
            });
        }

        getParameters(scope: ShareOnGooglePlusScope): string {
            var parameters = "";

            if (scope.shareUrl) {
                parameters += "url=" + this.encode(scope.shareUrl);
            }
            if (!scope.shareUrl && scope.useCurrentUrl) {
                parameters += "url=" + this.encode(this.$location.absUrl());
            }
            return parameters;
        }

        encode(value: string): string {
            return encodeURIComponent(value);
        }

        getTemplate(): string {
            return '<a href="{{url}}" target="_blank" data-ng-transclude=""></a>';
        }
    }

    export interface ShareOnGooglePlusScope extends ng.IScope {
        shareUrl: string;
        useCurrentUrl: boolean;
        url: string;
    }
}