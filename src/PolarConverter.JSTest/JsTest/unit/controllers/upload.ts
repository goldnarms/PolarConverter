/// <reference path="../../_all.ts" />

"use strict";
describe("Controller: uploadCtrl", () => {
    beforeEach(module("polarApp"));
    var uploadCtrl: PolarConverter.IUploadController;
    beforeEach(inject(($controller, $rootScope) => {
        var scope = $rootScope.$new();
        var uploadViewModel = {};
        uploadCtrl = $controller("uploadCtrl", {
            $scope: scope,
            uploadViewModel: uploadViewModel
        });
        uploadCtrl.uploadViewModel = { weight: 0, timeZoneOffset: 0, polarFiles: [], weightMode: "kg"};
    }));

    it("should initiate two empty lists", () => {
        expect(uploadCtrl.uploadedFiles.length).toBe(0);
        expect(uploadCtrl.gpxFiles.length).toBe(0);
    });

    it("should match correct gpx and hrm files", () => {
        var hrmFiles = <PolarConverter.PolarFile[]>[<PolarConverter.PolarFile>{ name: "12001.hrm"}];
        expect(uploadCtrl.checkForMatchingFile(hrmFiles, "12001.gpx")).toBeDefined();
    });

    it("should return null if no match", () => {
        var hrmFiles = <PolarConverter.PolarFile[]>[<PolarConverter.PolarFile>{ name: "12002.hrm" }];
        expect(uploadCtrl.checkForMatchingFile(hrmFiles, "12001.gpx")).toBe(undefined);
    });

    it("should set weightmode to imperial if user from USA", () => {
        var countryCode = "US";
        uploadCtrl.setWeightTypeBasedOnCountry(countryCode);
        expect(uploadCtrl.isMetricWeight).toBeFalsy();
    });

    it("should set weightmode to metric if user from Norway", () => {
        var countryCode = "NO";
        uploadCtrl.setWeightTypeBasedOnCountry(countryCode);
        expect(uploadCtrl.isMetricWeight).toBeTruthy();
    });

    it("should save timeZoneOffset", ()=> {
        var timeZone: PolarConverter.TimeZone = { offset: 12, text: "Offset" };
        uploadCtrl.setTimeZoneOffset(timeZone);
        expect(uploadCtrl.uploadViewModel.timeZoneOffset).toBe(12);
    });

    it("should clear file lists when cancel is clicked", () => {
        var hrmFile = <PolarConverter.PolarFile>{ name: "12001.hrm" };
        uploadCtrl.uploadedFiles.push(hrmFile);
        var gpxFile = <PolarConverter.GpxFile>{ name: "12001.gpx" };
        uploadCtrl.gpxFiles.push(gpxFile);
        uploadCtrl.reset();
        uploadCtrl.gpxFiles.length.toBe(0);
        uploadCtrl.uploadedFiles.length.toBe(0);
    });
});
