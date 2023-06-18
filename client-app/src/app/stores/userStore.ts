import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { User, UserFormValues } from "../models/user";
import { store } from "./store";

export default class UserStore {
	user: User | null = null;
	isGlobalAdmin: boolean | undefined = false;
	isLocalAdmin: boolean | undefined = false;

	constructor() {
		makeAutoObservable(this)
	}

	get isLoggedIn() {
		return !!this.user;
	}

	setIsGlobalAdmin = (state: boolean) => {
		this.isGlobalAdmin = state;
	}

	setIsLocalAdmin = (state: boolean) => {
		this.isGlobalAdmin = state;
	}

	login = async (creds: UserFormValues) => {
		try {
			const user = await agent.Account.login(creds);
			store.commonStore.setToken(user.token);
			runInAction(() => this.user = user);
			store.modalStore.closeModal();
			window.location.reload();
		} catch (error) {
			console.log(error);
		}
	}

	getIsGlobalAdmin = async () => {
		try {
			const result = await agent.Account.isGlobalAdmin();
			runInAction(() => this.isGlobalAdmin = result);
		} catch (error) {
			console.log(error);
		}
	}

	getIsLocalAdmin = async (higherEducationFacilityId: string) => {
		try {
			const result = await agent.Account.isLocalAdmin(higherEducationFacilityId);
			runInAction(() => this.isLocalAdmin = result);
		} catch (error) {
			console.log(error);
		}
	}

	logout = () => {
		store.commonStore.setToken(null);
		window.localStorage.removeItem('jwt');
		window.location.reload();
		this.user = null;
	}

	getUser = async () => {
		try {
			const user = await agent.Account.current();
			runInAction(() => this.user = user);
		} catch (error) {
			console.log(error);
		}
	}

	register = async (creds: UserFormValues) => {
		try {
			const user = await agent.Account.register(creds);
			store.commonStore.setToken(user.token);
			runInAction(() => this.user = user);
			store.modalStore.closeModal();
		} catch (error) {
			console.log(error)
		}
	}

	setImage = (image: string) => {
		if (this.user) this.user.image = image;
	}

	setDisplayName = (fullName: string) => {
		if (this.user) this.user.fullName = fullName;
	}
}