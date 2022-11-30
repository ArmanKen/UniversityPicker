import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Specialty } from "../models/specialty";
import { Step } from "../models/step";

export default class SpecialtyStore {
	specialties: Specialty[] = [];
	selectedSpecialty: Specialty | undefined = undefined;
	loadingInitial = false;


	constructor() {
		makeAutoObservable(this);
	}

	loadSpecialties = async () => {
		this.setLoadingInitial(true);
		try {
			const specialties = await agent.Specialties.list();
			runInAction(() => {
				specialties.forEach(specialty => {
					this.specialties.push(specialty);
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