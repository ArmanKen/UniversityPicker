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
			let selectedSpecialty = store.specilatyStore.selectedSpecialty
			if (selectedSpecialty !== undefined) {
				store.universityStore.universities.forEach(university => {
					this.disciplines.concat(university.specialties.find(x => x.code === selectedSpecialty!.code)?.disciplines!)
				})
			}
			else {
				this.disciplines.concat(store.specilatyStore.specialties.find(x => x.code === selectedSpecialty!.code)?.disciplines!)
			}
		} catch (error) {
			console.log(error);
		}
	}

	updateSelectedDisciplines = (discipline: Discipline) => {
		if (discipline.isSelected === false) {
			discipline.isSelected = true;
			this.selectedDisciplines?.push(discipline)
		}
		else {
			discipline.isSelected = false;
			this.selectedDisciplines = this.selectedDisciplines?.filter(disciplines => disciplines !== discipline)
		}
	}
}