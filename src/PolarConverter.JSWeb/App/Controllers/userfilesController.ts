/// <reference path="../_all.ts" />
module PolarConverter {
    "use strict";

    export interface IUserFilesController {
        fileList: PolarFile[];
        exportToStrava(file: File): void;
        exportToRunkeeper(file: File): void;
        userId: string;
    }

    export class UserFilesController implements IUserFilesController {
        public fileList: PolarFile[];
        public injection(): any[] {
            return ["common", "fileService", "cfpLoadingBar", "userService", UserFilesController];
        }
        static $inject = ["common", "fileService", "cfpLoadingBar"];

        public userId: string;
        constructor(private common: ICommonService, private fileService: IFileService, private cfpLoadingBar: PolarConverter.ILoadingBar, private userService: PolarConverter.IUserService) {
            this.init();
        }

        public exportToStrava(file: File): void {
            this.fileService.exportToService("Strava", file.reference, file.name, this.userId)
                .success(() => {
                })
                .catch((error) => {
                    this.common.log.error("Error: " + error);
                });
        }

        public exportToRunkeeper(file: File): void {
            this.fileService.exportToService("Runkeeper", file.reference, file.name, this.userId)
                .success(() => {
                })
                .catch((error) => {
                    this.common.log.error("Error: " + error);
                });
        }

        private init(): void {
            //this.fileList = [];
            this.cfpLoadingBar.start();
            this.userService.getUserId().then((userId) => {
                this.userId = userId.data;
                this.fileService.getFilesForUser(userId.data).then((data) => {
                    this.fileList = _.map(data.data, (pf: any) => {
                        return <PolarFile> { name: pf.name, reference: pf.reference };
                    });
                    this.cfpLoadingBar.complete();
                })
                    .catch((error) => {
                        this.cfpLoadingBar.complete();
                        this.common.log.error(error);
                    });
            });
            //if (!!User) {
            //}
        }
    }
}