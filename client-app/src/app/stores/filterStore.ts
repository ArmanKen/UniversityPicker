import { makeAutoObservable } from "mobx";
import { University } from "../models/university";
import { store } from "./store";

export default class FilterStore {
	filteredUniversities: University[] = [];
	enablePriceFilter: boolean = false;
	minPrice: number = 0;
	maxPrice: number = 0;
	allowedBudget = false;
	selectedRegion: string | undefined = undefined;
	countryTopMinPlace: boolean = false;

	constructor() {
		makeAutoObservable(this);
	}

	updateUniversityList = () => {
		this.filteredUniversities = store.universityStore.universities.filter(university => {
			if (this.countryTopMinPlace && university.countryTopRating === 0)
				return null;
			if (this.selectedRegion && !this.filterByRegion(university))
				return null;
			if (store.branchOfKnowledgeStore.selectedBranchOfKnowledge && !this.filterByBranchOfKnowledge(university))
				return null;
			if (store.specilatyStore.selectedSpecialty && !this.filterBySpecialty(university))
				return null;
			if (this.allowedBudget && !this.filterByBudget(university))
				return null;
			if (this.enablePriceFilter && !this.filterByRegion(university))
				return null;
			return university;
		})
	}

	filterByRegion = (university: University) => {
		return university.region === this.selectedRegion ?
			true : false;
	}

	filterByBranchOfKnowledge = (university: University) => {
		return university.specialties.some(specialty => specialty.code.toFixed().slice(0, -1) ===
			store.branchOfKnowledgeStore.selectedBranchOfKnowledge?.code) ?
			true : false;
	}

	filterBySpecialty = (university: University) => {
		return university.specialties.some(specialty => specialty.code === store.specilatyStore.selectedSpecialty?.code) ?
			true : false;
	}

	filterByPrice = (university: University) => {
		return this.minPrice < university.specialties.find(x => x === store.specilatyStore.selectedSpecialty)?.price! &&
			this.maxPrice > university.specialties.find(x => x === store.specilatyStore.selectedSpecialty)?.price! ?
			true : false;
	}

	filterByBudget = (university: University) => {
		return university.specialties.find(specialty => specialty.code === store.specilatyStore.selectedSpecialty?.code)?.budgetAllowed ?
			true : false;
	}

	changeSelectedRegion = (region: string | undefined) => this.selectedRegion = region;
}