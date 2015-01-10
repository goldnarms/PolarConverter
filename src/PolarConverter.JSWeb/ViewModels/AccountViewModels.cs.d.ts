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
		email: string;
	}
	interface registerViewModel {
		email: string;
		password: string;
		confirmPassword: string;
		weight: number;
		stravaEmail: string;
		forceGarmin: boolean;
		preferKg: boolean;
		isMale: boolean;
		timeZoneOffset: number;
		birthDate: string;
		accessToken: string;
		providerType: any;
	}
	interface sendCodeViewModel {
		selectedProvider: string;
		providers: any[];
		returnUrl: string;
		rememberMe: boolean;
	}
	interface verifyCodeViewModel {
		provider: string;
		code: string;
		returnUrl: string;
		rememberBrowser: boolean;
		rememberMe: boolean;
	}
	interface forgotViewModel {
		email: string;
	}
}
