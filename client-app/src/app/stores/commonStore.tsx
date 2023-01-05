import { makeAutoObservable } from "mobx";
import { ServerError } from "../models/serverError";

export default class CommonStore {
	error: ServerError | null = null;
	appLoaded = false;

	constructor() {
		makeAutoObservable(this);
	}
	// 	reaction(
	// 		() => this.token,
	// 		token => {
	// 			if (token) {
	// 				window.localStorage.setItem('jwt', token)
	// 			} else {
	// 				window.localStorage.removeItem('jwt')
	// 			}
	// 		}
	// 	)
	// }

	setServerError = (error: ServerError) => this.error = error;

	// setToken = (token: string | null) => {
	// 	this.token = token;
	// }

	setAppLoaded = () => this.appLoaded = true;
}