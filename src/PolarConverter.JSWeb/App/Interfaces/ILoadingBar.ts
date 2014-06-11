 module PolarConverter {
     "use strict";
     export interface ILoadingBar {
         start(): void;
         inc(): void;
         set(precentage: number): void;
         status(): number;
         complete(): void;
     }
 }