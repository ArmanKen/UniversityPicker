import { makeAutoObservable } from "mobx";
import { DropdownItemProps } from "semantic-ui-react";
import { Specialty } from "../models/specialty";
import { store } from "./store";

export default class SpecilatyStore {
	specialties: Specialty[] = [];
	selectedSpecialty: Specialty | undefined = undefined;
	dropdownContent: DropdownItemProps[] = [];

	constructor() {
		makeAutoObservable(this);
	}

	loadSpecialties = () => {
		try {
			store.universityStore.universities.forEach(university => {
				university.specialties.forEach(specialty => {
					let specialtyCode = specialty.code.toFixed().slice(0, -1);
					let branchOfKnowledgeCode = store.branchOfKnowledgeStore.selectedBranchOfKnowledge?.code;
					if (specialtyCode === branchOfKnowledgeCode &&
						!this.specialties.some(x => x.code === specialty.code))
						this.specialties.push(specialty);
				})
			})
		} catch (error) {
			console.log(error);
		}
	}

	loadDropdownContent = () => {
		try {
			this.specialties.forEach(specialty =>
				this.dropdownContent.push({ key: specialty.id, text: specialty.name, value: specialty.code })
			);
		} catch (error) {
			console.log(error);
		}
		return this.dropdownContent;
	}

	changeSelectedSpecialty = (value: number) => {
		this.selectedSpecialty = this.specialties.find(specialty => specialty.code === value);
	}
}