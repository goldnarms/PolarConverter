/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";

    export interface IUserFilesController {
        fileList: PolarFile[];
    }

    export class UserFilesController implements IUserFilesController {
        public fileList: PolarFile[];
        public injection(): any[] {
            return ["common", "fileService", "cfpLoadingBar", UserFilesController];
        }
        static $inject = ["common", "fileService", "cfpLoadingBar"];
        constructor(private common: ICommonService, private fileService: IFileService, private cfpLoadingBar: PolarConverter.ILoadingBar) {
            //User = new <User>;
            //User.id = 1;
            this.init();
        }

        public exportToStrava(fileRef: string): void {
            
        }

        private init(): void {
            //this.fileList = [];
            this.cfpLoadingBar.start();
            this.fileService.getFilesForUser(1).then((data) => {
                this.fileList = _.map(data.data, (pf: any) => {
                    return <PolarFile> { name: pf.Name, reference: pf.Reference };
                });
                this.cfpLoadingBar.complete();
            })
                .catch((error) => {
                    this.cfpLoadingBar.complete();
                    this.common.log.error(error);
                });
            //if (!!User) {
            //}
        }
    }
}