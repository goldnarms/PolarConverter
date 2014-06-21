module PolarConverter {
    "use strict";
    export interface UserViewModel {
        id: number;
        weight: number;
        stravaEmail: string;
        forceGarmin: boolean;
        preferKg: boolean;
        isMale: boolean;
        timeZoneOffset: number;
        birthDate: Date;
    }
}