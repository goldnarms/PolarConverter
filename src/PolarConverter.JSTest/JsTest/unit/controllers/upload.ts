/// <reference path="../../_all.ts" />

"use strict";
describe("Controller: uploadCtrl", () => {
    beforeEach(module("polarApp"));
    var uploadCtrl: PolarConverter.UploadController;
    beforeEach(inject(($controller, $rootScope) => {
        var scope = $rootScope.$new();
        uploadCtrl = $controller("uploadCtrl", {
            $scope: scope
        });
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
        expect(uploadCtrl.checkForMatchingFile(hrmFiles, "12001.gpx")).not.toBeDefined();
    });
});
