declare module server {
	interface uploadViewModel {
		weight: number;
		weightMode: string;
		timeZoneOffset: number;
		forceGarmin: boolean;
		polarFiles: {
			name: string;
			reference: string;
			fileType: string;
			sport: string;
			gpxFile: {
				name: string;
				reference: string;
			};
			note: string;
		}[];
		notes: string;
	}
}
