import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { University } from "../models/university";

export default class UniversityStore {
	universities: University[] = [];
	loadingInitial = false;

	constructor() {
		makeAutoObservable(this);
	}

	loadUniversities = async () => {
		this.setLoadingInitial(true);
		try {
			const universities = await agent.Universities.list();
			runInAction(() => {
				universities.forEach(university => {
					this.universities.push(university);
				})
			})
			this.setLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
		}
	}

	setLoadingInitial = (state: boolean) => {
		this.loadingInitial = state;
	}
}