/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="Models/IFilePicker.ts" />
/// <reference path="Models/File.ts" />
/// <reference path="Models/Sport.ts" />
'use strict';
declare var filepicker: App.IFilePicker;

// Declare app level module which depends on filters, and services
var myApp = angular.module('myApp', []);
//'app.filters', 'app.services', 'app.directives'
module App {
    export class FrontPageController {
        static $inject = ["$scope", "$rootScope", "$http", "$location"];
        constructor(private $scope: IFrontPageScope, private $rootScope: ng.IRootScopeService, private $http: ng.IHttpService, private $location: ng.ILocationService) {
            $scope.files = [];
            $scope.pickFiles = angular.bind(this, this.pickFiles);
            $scope.sports = [<App.Sport>{ sportName: "Biking" }, <App.Sport>{ sportName: "Running" }, < App.Sport > { sportName: "Other" }];
            filepicker.setKey("AjmINjgSkQGOzaXwiZs0hz");
        }

        pickFiles(): void {
            //debug: true, 
            filepicker.pickMultiple({ extensions: ['.hrm', '.xml', ".gpx"], services: ["COMPUTER", "DROPBOX", "SKYDRIVE", "GOOGLE_DRIVE", "BOX"] }, (InkBlobs: App.File[]) => {
                this.$scope.files = InkBlobs;
                this.$http.post("/api/File", InkBlobs);
                this.$scope.result = JSON.stringify(InkBlobs);
                this.$scope.$apply();
            }, (error) => {
                    alert(error);
                });
        }
    }

    export interface IFrontPageScope extends ng.IScope {
        pickFiles: Function;
        files: App.File[];
        result: string;
        sports: App.Sport[];
    }
}