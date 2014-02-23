module PolarConverter {
    "use strict";

    export interface UploadViewModel {
        weight: number;
        weightMode: string;
        timeZoneOffset: number;
        forceGarmin: boolean;
        polarFiles: PolarConverter.PolarFile[];
    }
}
