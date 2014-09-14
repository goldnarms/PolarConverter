declare module server {
	interface externalLoginConfirmationViewModel {
		userName: string;
	}
	interface manageUserViewModel {
		oldPassword: string;
		newPassword: string;
		confirmPassword: string;
	}
	interface loginViewModel {
		userName: string;
		password: string;
		rememberMe: boolean;
	}
	interface registerViewModel {
		userName: string;
		password: string;
		confirmPassword: string;
		weight: number;
		stravaEmail: string;
		forceGarmin: boolean;
		preferKg: boolean;
		isMale: boolean;
		timeZoneOffset: number;
		birthDate: string;
	}
}
