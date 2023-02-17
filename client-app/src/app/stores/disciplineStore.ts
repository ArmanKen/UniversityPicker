import { makeAutoObservable } from "mobx";
import { Discipline } from "../models/discipline";
import { store } from "./store";

export default class DisciplineStore {
	// disciplines: Discipline[] = [];

	// constructor() {
	// 	makeAutoObservable(this);
	// }

	// loadDisciplines = () => {
	// 	try {
	// 		let selectedSpecialty = store.specilatyStore.selectedSpecialty;
	// 		if (selectedSpecialty !== undefined) {
	// 			store.universityStore.universities.forEach(university => {
	// 				let disciplines = university.specialties.find(x => x.code === selectedSpecialty!.code)?.disciplines!;
	// 				disciplines.forEach(newDiscipline => {
	// 					if (!this.disciplines.some(discipline => discipline.id === newDiscipline.id))
	// 						this.disciplines.push(newDiscipline);
	// 				});
	// 			})
	// 		}
	// 		else {
	// 			store.specilatyStore.selectedSpecialties.forEach(specialty => {
	// 				specialty.disciplines!.forEach(discipline => {
	// 					if (!this.disciplines.some(x => x.id === discipline.id)) {
	// 						this.disciplines.push(discipline);
	// 					}
	// 				})
	// 			})
	// 		}
	// 	} catch (error) {
	// 		console.log(error);
	// 	}
	// }

	// updateSelectedDisciplines = (discipline: Discipline) => discipline.isSelected ?
	// 	discipline.isSelected = false : discipline.isSelected = true;

	// clearSelectedDisciplines = () => this.disciplines.forEach(discipline => discipline.isSelected = false)

	// selectAllDisciplines = () => this.disciplines.forEach(discipline => discipline.isSelected = true)

	// undoDisciplineStore = () => {
	// 	this.clearSelectedDisciplines();
	// 	this.disciplines = [];
	// }
}