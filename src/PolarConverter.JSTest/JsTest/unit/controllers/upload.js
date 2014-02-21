/// <reference path="../../_all.ts" />
"use strict";
describe("Controller: uploadCtrl", function () {
    beforeEach(module("polarApp"));
    var uploadCtrl;
    beforeEach(inject(function ($controller, $rootScope) {
        var scope = $rootScope.$new();
        var uploadViewModel = {};
        uploadCtrl = $controller("uploadCtrl", {
            $scope: scope,
            uploadViewModel: uploadViewModel
        });
        uploadCtrl.uploadViewModel = { weight: 0, timeZoneOffset: 0, polarFiles: [], weightMode: "kg" };
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

    it("should set weightmode to imperial if user from USA", function () {
        var countryCode = "US";
        uploadCtrl.setWeightTypeBasedOnCountry(countryCode);
        expect(uploadCtrl.isMetricWeight).toBeFalsy();
    });

    it("should set weightmode to metric if user from Norway", function () {
        var countryCode = "NO";
        uploadCtrl.setWeightTypeBasedOnCountry(countryCode);
        expect(uploadCtrl.isMetricWeight).toBeTruthy();
    });

    it("should save timeZoneOffset to localstorage", function () {
        var timeZone = { offset: 12, text: "Offset" };
        uploadCtrl.setTimeZoneOffset(timeZone);
        expect(uploadCtrl.uploadViewModel.timeZoneOffset).toBe(12);
    });
});
