declare var filepicker: IFilePicker;
class PcFilePicker {
    constructor() {
        filepicker.setKey("AjmINjgSkQGOzaXwiZs0hz");
        filepicker.pickMultiple({ extensions: ['.hrm', '.xml', ".gpx"]}, (InkBlobs) => {
                console.log(JSON.stringify(InkBlobs));
            });
    }
}
//{ location: "S3" }
export interface IFilePicker {
    setKey(key: string): void;
    pickMultiple(options:any, onSuccess?: Function, onError?: Function): void;
}