/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";
    export interface PolarFile extends PolarConverter.File {
        fileType: PolarConverter.fileType;
        sport: PolarConverter.sportEnum;
        checked: boolean;
        gpxFile: PolarConverter.GpxFile;
    }
}