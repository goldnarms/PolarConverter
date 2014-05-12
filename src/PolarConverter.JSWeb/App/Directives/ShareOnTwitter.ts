/// <reference path="../_all.ts" />

module PolarConverter {
    "use strict";

    export class ShareOnTwitter {
        static $inject = ["$location"];
        public injection(): any[] {
            return ["$location", ($location) => { return new ShareOnTwitter($location); }];
        }

        public restrict: string;
        public transclude: boolean;
        public replace: boolean;
        public template: string;
        public scope: any;
        public link: (scope: ShareOnTwitterScope, element: JQuery, attrs: ng.IAttributes) => void;

        constructor(private $location: ng.ILocationService) {
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
            this.link = (scope, element, attrs) => this.linkFn(scope, element, attrs);
        }

        linkFn(scope: ShareOnTwitterScope, element: JQuery, attrs: ng.IAttributes) {
            scope.$watch("tweetText", () => {
                var url = "https://twitter.com/share";
                var parameters = this.getParameters(scope);
                scope.url = parameters === "" ? url : url + "?" + parameters;
            });

            element.bind("click", (event) => {
                window.open(scope.url, "twitter-share-dialog", "menubar=no,toolbar=no,resizable=yes,scrollbars=yes,status=no,width=550,height=450");
                event.preventDefault();
            });
        }

        getParameters(scope: ShareOnTwitterScope): string {
            var parameters: string[] = [];

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
        }

        encode(value: string): string {
            return encodeURIComponent(value);
        }

        getTemplate(): string {
            return '<a data-ng-href="{{url}}" target="_blank" data-ng-transclude=""></a>';
        }
    }

    export interface ShareOnTwitterScope extends ng.IScope {
        tweetUrl: string;
        tweetVia: string;
        tweetText: string;
        tweetRelated: string;
        url: string;
        useCurrentUrl: boolean;
    }
}