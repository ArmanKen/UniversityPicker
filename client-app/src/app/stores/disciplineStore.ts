import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Discipline } from "../models/discipline";

export default class DisciplineStore {
	disciplines: Discipline[] = [];
	selectedDisciplines = new Map<string, Discipline>();
	loading = false;
	loadingInitial = false;

	constructor() {
		makeAutoObservable(this);
	}

	loadDisciplines = async () => {
		this.loadingInitial = true;
		try {
			const disciplines = await agent.Disciplines.list();
			runInAction(() => {
				disciplines.forEach(discipline => {
					this.disciplines.push(discipline);
				})
			})
			this.loadingInitial = false;
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.loadingInitial = false;
		}
	}

	addToSelectedDisciplines = (discipline: Discipline) => {
		this.selectedDisciplines.set(discipline.id, discipline);
	}

	deleteFromSelectedDisciplines = (discipline: Discipline) => {
		this.selectedDisciplines.delete(discipline.id)
	}
}