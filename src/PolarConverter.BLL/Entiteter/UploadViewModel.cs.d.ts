declare module server {
	interface uploadViewModel {
		uid: string;
		weight: number;
		weightMode: string;
		timeZoneOffset: number;
		v02Max: number;
		age: number;
		gender: string;
		forceGarmin: boolean;
		polarFiles: {
			name: string;
			reference: string;
			fileType: string;
			sport: string;
			gpxFile: {
				name: string;
				reference: string;
				version: string;
			};
			note: string;
		}[];
		notes: string;
	}
}
