/// <reference path="../Models/File.ts" />
module App {
    export interface IFilePicker {
        setKey(key: string): void;
        pickMultiple(options: any, onSuccess?: Function, onError?: Function): void;
    }
}