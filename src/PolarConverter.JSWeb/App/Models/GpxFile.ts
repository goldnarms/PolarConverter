module PolarConverter {
    "use strict";

    export interface GpxFile extends PolarConverter.File {
        matched: boolean;
        version: string;
    }
}