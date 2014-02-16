/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";
    export interface PolarFile {
        name: string;
        reference: string;
        fileType: PolarConverter.FileType;
        sport: PolarConverter.Sport;
        checked: boolean;
    }
}