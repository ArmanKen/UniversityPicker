import { makeAutoObservable } from "mobx";
import { Discipline } from "../models/discipline";
import { store } from "./store";

export default class DisciplineStore {
	disciplines: Discipline[] = [];

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
		discipline.isSelected === true ?
			discipline.isSelected = false
			: discipline.isSelected = true;
	}

	clearSelectedDisciplines = () => {
		this.disciplines.forEach(discipline => {
			discipline.isSelected = false;
		})
	}

	selectAllDisciplines = () => {
		this.disciplines.forEach(discipline => {
			discipline.isSelected = true;
		})
	}

	undoDisciplineStore = () => {
		this.clearSelectedDisciplines();
		this.disciplines.length = 0;
	}
}