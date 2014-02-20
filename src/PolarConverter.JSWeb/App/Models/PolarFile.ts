/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";
    export interface PolarFile extends PolarConverter.File {
        fileType: PolarConverter.FileType;
        sport: PolarConverter.SportEnum;
        checked: boolean;
        gpxFile: PolarConverter.GpxFile;
    }
}