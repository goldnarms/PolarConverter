/// <reference path="../../Scripts/typings/angularjs/angular.d.ts" />
module PolarConverter {
    export interface IStorage {
        isSupported(): boolean;
        add(key: string, value: any): boolean;
        get(key: string): any;
        remove(key: string): boolean;
        clearAll(): void;
		keys(): string[];
    }
}