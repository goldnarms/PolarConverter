/// <reference path="../_all.ts" />

module PolarConverter {
    "use strict";

    export class ShareOnFacebook {
        public injection(): any[] {
            return ["$location", ($location) => { return new ShareOnFacebook($location); }];
        }

        public restrict: string;
        public transclude: boolean;
        public replace: boolean;
        public template: string;
        public scope: any;
        public link: (scope: ShareOnFacebookScope, element: JQuery, attrs: ng.IAttributes) => void;
        static $inject = ["$location"];

        constructor(private $location: ng.ILocationService) {
            this.restrict = "A";
            this.transclude = true;
            this.replace = true;
            this.template = this.getTemplate();
            this.scope = {
                fullFacebookUrl: "=", //Use this to specify the entire url to facebook
                shareUrl: "@url",        //Use this to share shareUrl with https://www.facebook.com/sharer/sharer.php
                useCurrentUrl: "@"       //Use this to share the current url with https://www.facebook.com/sharer/sharer.php
            };
            this.link = (scope, element, attrs) => this.linkFn(scope, element, attrs);
        }

        linkFn(scope: ShareOnFacebookScope, element: JQuery, attrs: ng.IAttributes) {
            scope.$watch("fullFacebookUrl", () => {
                if (scope.fullFacebookUrl != null) {
                    scope.url = scope.fullFacebookUrl;
                }
            });

            if (scope.fullFacebookUrl) {
                scope.url = scope.fullFacebookUrl;
            } else {
                var url = "https://www.facebook.com/sharer/sharer.php";
                var parameters = this.getParameters(scope);
                scope.url = parameters === "" ? url : url + "?" + parameters;
            }

            element.bind("click", (event) => {
                window.open(scope.url, "facebook-share-dialog", "menubar=no,toolbar=no,resizable=yes,scrollbars=yes,status=no,width=626,height=436");
                event.preventDefault();
            });
        }

        getParameters(scope: ShareOnFacebookScope): string {
            var parameters = "";

            if (scope.shareUrl) {
                parameters += "u=" + this.encode(scope.shareUrl);
            }
            if (!scope.shareUrl && scope.useCurrentUrl) {
                parameters += "u=" + this.encode(this.$location.absUrl());
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

    export interface ShareOnFacebookScope extends ng.IScope {
        fullFacebookUrl: string;
        shareUrl: string;
        useCurrentUrl: boolean;
        url: string;
    }
}