import { makeAutoObservable } from "mobx";
import { Discipline } from "../models/discipline";
import { store } from "./store";

export default class DisciplineStore {
	disciplines: Discipline[] = [];
	selectedDisciplines: Discipline[] | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
	}

	loadDisciplines = () => {
		try {
			let selectedSpecialty = store.specilatyStore.selectedSpecialty;
			if (selectedSpecialty !== undefined) {
				store.universityStore.universities.forEach(university => {
					this.disciplines = this.disciplines.concat(university.specialties.find(x => x.code === selectedSpecialty!.code)?.disciplines!);
				})
			}
			else {
				store.specilatyStore.specialties.forEach(specialty => {
					specialty.disciplines!.forEach(discipline => {
						if (!this.disciplines.some(x => x.id === discipline.id)) {
							this.disciplines.push(discipline);
						}
					})
				})
			}
		} catch (error) {
			console.log(error);
		}
	}

	updateSelectedDisciplines = (discipline: Discipline) => {
		if (discipline.isSelected === true) {
			discipline.isSelected = false;
			this.selectedDisciplines = this.selectedDisciplines?.filter(disciplines => disciplines !== discipline);
		}
		else {
			discipline.isSelected = true;
			this.selectedDisciplines?.push(discipline);
		}
	}
}