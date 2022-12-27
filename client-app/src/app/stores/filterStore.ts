import { makeAutoObservable } from "mobx";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";
import { Discipline } from "../models/discipline";
import { Specialty } from "../models/specialty";

export default class FilterStore {
	selectedBranchOfKnowledge: BranchOfKnowledge | undefined;
	selectedSpecialty: Specialty | undefined;
	selectedDisciplines: Discipline[] = [];
	minPrice: number = 0;
	maxPrice: number = 0;
	allowedBudget = true;
	selectedRegion: string | undefined;
	selectedCity: string | undefined;
	countryTopMinPlace: number = 0;

	constructor() {
		makeAutoObservable(this);
	}
}