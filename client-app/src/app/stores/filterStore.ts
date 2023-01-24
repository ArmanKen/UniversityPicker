import { makeAutoObservable } from "mobx";
import { University } from "../models/university";
import { store } from "./store";

export default class FilterStore {
	loading: boolean = false;
	filteredUniversities: University[] = [];
	minPrice: number = 0;
	maxPrice: number = 0;
	allowedBudget = false;
	selectedRegion: string | undefined = undefined;
	countryTopMinPlace: boolean = false;

	constructor() {
		makeAutoObservable(this);
	}

	updateUniversityList = () => {
		this.loading = true
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
			if (store.specilatyStore.selectedSpecialty && (this.minPrice | this.maxPrice) && !this.filterByPrice(university))
				return null;
			return university;
		})
		this.loading = false;
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
		let minPriceTrue = !!this.minPrice;
		let maxPriceTrue = !!this.maxPrice;
		if (minPriceTrue)
			minPriceTrue =  this.minPrice <= university.specialties.find(x => x.code === store.specilatyStore.selectedSpecialty?.code)?.price!;
		else minPriceTrue = true;
		if (maxPriceTrue)
			maxPriceTrue = this.maxPrice >= university.specialties.find(x => x.code === store.specilatyStore.selectedSpecialty?.code)?.price!
		else maxPriceTrue = true;
		return maxPriceTrue && minPriceTrue;
	}

	filterByBudget = (university: University) => {
		return university.specialties.find(specialty => specialty.code === store.specilatyStore.selectedSpecialty?.code)?.budgetAllowed ?
			true : false;
	}

	changeSelectedRegion = (region: string | undefined) => this.selectedRegion = region;

	changeMinPrice = (price: number) => this.minPrice = price;

	changeMaxPrice = (price: number) => this.maxPrice = price;
}