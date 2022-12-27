import { makeAutoObservable } from "mobx";
import { DropdownItemProps } from "semantic-ui-react";
import { Specialty } from "../models/specialty";
import { store } from "./store";

export default class SpecilatyStore {
	specialties: Specialty[] = [];
	selectedSpecialties: Specialty[] = [];
	selectedSpecialty: Specialty | undefined = undefined;
	dropdownContent: DropdownItemProps[] = [];

	constructor() {
		makeAutoObservable(this);
	}

	loadSpecialties = () => {
		try {
			store.universityStore.universities.forEach(university => {
				university.specialties.forEach(specialty => {
					if (!this.specialties.some(x => x.code === specialty.code))
						this.specialties.push(specialty);
				})
			})
			this.specialties = this.specialties.sort((s1, s2) => s1.code - s2.code);
		} catch (error) {
			console.log(error);
		}
	}

	updateSelectedSpecialties = () => {
		this.specialties.forEach(specialty => {
			let specialtyCode = specialty.code.toFixed().slice(0, -1);
			if (specialtyCode === store.branchOfKnowledgeStore.selectedBranchOfKnowledge?.code) {
				this.selectedSpecialties.push(specialty);
				this.dropdownContent.push({ key: specialty.id, text: specialty.name, value: specialty.code });
			}
		}
		)
	}

	changeSelectedSpecialty = (value: number | undefined) => {
		value === undefined ?
			this.selectedSpecialty = undefined
			: this.selectedSpecialty = this.specialties.find(specialty => specialty.code === value);
		store.disciplineStore.undoDisciplineStore();
	}

	undoSpecialtyStore = () => {
		store.disciplineStore.undoDisciplineStore();
		this.selectedSpecialty = undefined;
		this.selectedSpecialties = [];
		this.dropdownContent = [];
	}
}