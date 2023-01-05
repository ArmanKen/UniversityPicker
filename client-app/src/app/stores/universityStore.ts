import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { University } from "../models/university";
import { store } from "./store";

export default class UniversityStore {
	universities: University[] = [];
	selectedUniversity: University | undefined = undefined;
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
			store.specilatyStore.loadSpecialties();
			this.setLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
		}
	}

	setLoadingInitial = (state: boolean) => this.loadingInitial = state;

	getUniversitySelectedSpecialty = (university: University) => {
		return university.specialties.find(x => x.code === store.specilatyStore.selectedSpecialty?.code)
	}

	getFilteredUniversities = () => {

	}

	setSelectedUniversity = (university: University | undefined) => this.selectedUniversity = university;
}