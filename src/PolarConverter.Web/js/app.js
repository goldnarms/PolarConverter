/// <reference path="../Scripts/typings/angularjs/angular.d.ts" />
/// <reference path="Models/IFilePicker.ts" />
/// <reference path="Models/File.ts" />
/// <reference path="Models/Sport.ts" />
'use strict';
// Declare app level module which depends on filters, and services
var myApp = angular.module('myApp', []);

//'app.filters', 'app.services', 'app.directives'
var App;
(function (App) {
    var FrontPageController = (function () {
        function FrontPageController($scope, $rootScope, $http, $location) {
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$http = $http;
            this.$location = $location;
            $scope.files = [];
            $scope.pickFiles = angular.bind(this, this.pickFiles);
            $scope.sports = [{ sportName: "Biking" }, { sportName: "Running" }, { sportName: "Other" }];
            filepicker.setKey("AjmINjgSkQGOzaXwiZs0hz");
        }
        FrontPageController.prototype.pickFiles = function () {
            var _this = this;
            //debug: true,
            filepicker.pickMultiple({ extensions: ['.hrm', '.xml', ".gpx"], services: ["COMPUTER", "DROPBOX", "SKYDRIVE", "GOOGLE_DRIVE", "BOX"] }, function (InkBlobs) {
                _this.$scope.files = InkBlobs;
                _this.$http.post("/api/File", InkBlobs);
                _this.$scope.result = JSON.stringify(InkBlobs);
                _this.$scope.$apply();
            }, function (error) {
                alert(error);
            });
        };
        FrontPageController.$inject = ["$scope", "$rootScope", "$http", "$location"];
        return FrontPageController;
    })();
    App.FrontPageController = FrontPageController;
})(App || (App = {}));
//# sourceMappingURL=app.js.map
