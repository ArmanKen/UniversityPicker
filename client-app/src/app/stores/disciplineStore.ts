import { makeAutoObservable } from "mobx";
import { Discipline } from "../models/discipline";
import { store } from "./store";

export default class DisciplineStore {
	disciplines: Discipline[] = [];
	selectedSpecialty: Discipline[] | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
	}

	loadSpecialties = () => {
		// try {
		// 	store.universityStore.universities.forEach(university => {
		// 		university.specialties.filter(x => x.code == store.specilatyStore.selectedSpecialty?.code).forEach(specialty => {
		// 			let specialtyCode = specialty.code;
		// 			this.disciplines.
		// 		})
		// 	})
		// } catch (error) {
		// 	console.log(error);
		// }
	}
}