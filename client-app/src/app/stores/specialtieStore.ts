import { makeAutoObservable } from "mobx";
import { Specialtie } from "../models/specialtie";

export default class SpecialtieStore {
	specialties: Specialtie[] = [];
	selectedSpecialtie: Specialtie | undefined = undefined;
	loadingInitial = false;
	specialtieSelectionActive = true;
	specialtieSelectionCompleted = false;

	constructor() {
		makeAutoObservable(this);
	}
}