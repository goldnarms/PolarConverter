declare module server {
	interface polarFile extends server.file{
		type: any;
		sport: any;
		checked: boolean;
		gpxFile: server.gpxFile;
	}
}
