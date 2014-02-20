/// <reference path="../../_all.ts" />
"use strict";
describe("Controller: uploadCtrl", function () {
    beforeEach(module("polarApp"));
    var uploadCtrl;
    beforeEach(inject(function ($controller, $rootScope) {
        var scope = $rootScope.$new();
        uploadCtrl = $controller("uploadCtrl", {
            $scope: scope
        });
    }));

    it("should initiate two empty lists", function () {
        expect(uploadCtrl.uploadedFiles.length).toBe(0);
        expect(uploadCtrl.gpxFiles.length).toBe(0);
    });

    it("should match correct gpx and hrm files", function () {
        var hrmFiles = [{ name: "12001.hrm" }];
        expect(uploadCtrl.checkForMatchingFile(hrmFiles, "12001.gpx")).toBeDefined();
    });

    it("should return null if no match", function () {
        var hrmFiles = [{ name: "12002.hrm" }];
        expect(uploadCtrl.checkForMatchingFile(hrmFiles, "12001.gpx")).not.toBeDefined();
    });
});
