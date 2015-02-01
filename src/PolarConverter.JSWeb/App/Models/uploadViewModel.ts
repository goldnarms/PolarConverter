module PolarConverter {
    "use strict";

    export interface UploadViewModel {
        uid?: string;
        gender?: string;
        weight?: number;
        weightMode?: string;
        timeZoneOffset?: number;
        forceGarmin: boolean;
        polarFiles: PolarConverter.PolarFile[];
		age: number;
    }
}
