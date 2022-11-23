import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Specialtie } from "../models/specialtie";

export default class SpecialtieStore {
	specialties = new Map<string, Specialtie>();
	selectedSpecialtie: Specialtie | undefined = undefined;
	loadingInitial = false;
	specialtieSelectionActive = true;
	specialtieSelectionCompleted = false;

	constructor() {
		makeAutoObservable(this);
	}

	loadDisciplines = async () => {
		this.setLoadingInitial(true);
		try {
			const specialties = await agent.Specialties.list();
			runInAction(() => {
				specialties.forEach(specialtie => {
					this.specialties.set(specialtie.id, specialtie);
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