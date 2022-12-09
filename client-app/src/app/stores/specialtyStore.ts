import { makeAutoObservable } from "mobx";
import { Specialty } from "../models/specialty";
import { store } from "./store";

export default class SpecilatyStore {
	specialties: Specialty[] = [];
	selectedSpecialty: Specialty | undefined = undefined;
	loadingInitial = false;

	constructor() {
		makeAutoObservable(this);
	}

	loadSpecialties = () => {
		try {
			store.universityStore.universities.forEach(university => {
				university.specialties.forEach(specialty => {
					let specialtyCode = specialty.code.toFixed().slice(0, -1);
					let branchOfKnowledgeCode = store.branchOfKnowledgeStore.selectedBranchOfKnowledge?.code;
					if (specialtyCode === branchOfKnowledgeCode && !this.specialties.some(x => x.code === specialty.code))
						this.specialties.push(specialty);
				})
			})
		} catch (error) {
			console.log(error);
		}
	}
}