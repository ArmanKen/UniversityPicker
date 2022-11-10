import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { Discipline } from "../models/discipline";

export default class DisciplineStore {
	disciplineRegistry = new Map<string, Discipline>();
	selectedDisciplines: Discipline[] | undefined = undefined;
	loading = false;
	loadingInitial = false;

	constructor() {
		makeAutoObservable(this);
	}

	private setDiscipline = (discipline: Discipline) => {
		this.disciplineRegistry.set(discipline.id, discipline);
	}

	setLoadingInitial = (state: boolean) => {
		this.loadingInitial = state;
	}

	loadActivities = async () => {
		this.loadingInitial = true;
		try {
			const disciplines = await agent.Disciplines.list();
			disciplines.forEach(discipline => {
				this.setDiscipline(discipline)
			})
			this.setLoadingInitial(false);
		} catch (error) {
			console.log(error);
			this.setLoadingInitial(false);
		}
	}
}