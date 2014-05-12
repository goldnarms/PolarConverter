module PolarConverter {
    "use strict";

    export interface UploadViewModel {
        gender?: string;
        weight?: number;
        weightMode?: string;
        timeZoneOffset?: number;
        forceGarmin: boolean;
        polarFiles: PolarConverter.PolarFile[];
    }
}
