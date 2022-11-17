import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Discipline } from "../models/discipline";

export default class DisciplineStore {
	disciplines = new Map<string, Discipline>();
	selectedDisciplines = new Map<string, Discipline>();
	loadingInitial = false;

	constructor() {
		makeAutoObservable(this);
	}

	loadDisciplines = async () => {
		this.setLoadingInitial(true);
		try {
			const disciplines = await agent.Disciplines.list();
			runInAction(() => {
				disciplines.forEach(discipline => {
					this.disciplines.set(discipline.id, discipline);
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

	updateSelectedDisciplines = (discipline: Discipline) => {
		if (this.selectedDisciplines.has(discipline.id)) {
			discipline.isSelected = false;
			this.selectedDisciplines.delete(discipline.id);
		} else {
			discipline.isSelected = true;
			this.selectedDisciplines.set(discipline.id, discipline)
		}
	}
}