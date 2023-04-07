import { makeAutoObservable, runInAction } from "mobx";
import { DropdownItemProps } from "semantic-ui-react";
import agent from "../api/agent";

export default class UIStore {
	uiLoadingInitial = false;
	degrees: DropdownItemProps[] = [];
	regions = new Map<DropdownItemProps, DropdownItemProps[]>();
	cities: DropdownItemProps[] = [];
	currentStatuses: DropdownItemProps[] = [];
	knowledgeBranches = new Map<DropdownItemProps, DropdownItemProps[]>();
	specialtyBases: DropdownItemProps[] = [];
	languages: DropdownItemProps[] = [];
	studyForms: DropdownItemProps[] = [];
	accreditations: DropdownItemProps[] = [];

	constructor() {
		makeAutoObservable(this);
		this.loadDropdowns();
	}

	setUiLoadingInitial = (state: boolean) => this.uiLoadingInitial = state;

	clearDropdowns = () => {
		this.degrees = [];
		this.regions.clear();
		this.currentStatuses = [];
		this.knowledgeBranches.clear();
		this.languages = [];
		this.studyForms = [];
		this.accreditations = [];
	}

	loadDropdowns = async () => {
		this.setUiLoadingInitial(true);
		try {
			const result = await agent.UI.list();
			runInAction(() => {
				this.clearDropdowns();
				this.degrees = result.degrees.map(degree => ({
					key: degree.id + degree.name,
					value: degree.id,
					text: degree.name,
				}));
				result.regions.forEach(region => {
					const cities: DropdownItemProps[] = region.cities.map(city => ({
						key: city.id + city.name + region.id,
						value: city.id,
						text: city.name + ', ' + region.name,
					}));
					this.regions.set({
						key: region.id + region.name,
						value: region.id,
						text: region.name,
					}, cities);
				});
				this.currentStatuses = result.currentStatuses.map(currentStatus => ({
					key: currentStatus.id + currentStatus.status,
					value: currentStatus.id,
					text: currentStatus.status,
				}));
				result.knowledgeBranches.forEach(knowledgeBranch => {
					const specialtyBases = knowledgeBranch.specialtyBases.map(specialtyBase => ({
						key: specialtyBase.id + specialtyBase.name + knowledgeBranch.id,
						value: specialtyBase.id,
						text: specialtyBase.name,
					}));
					this.knowledgeBranches.set({
						key: knowledgeBranch.id + knowledgeBranch.name,
						value: knowledgeBranch.id,
						text: knowledgeBranch.name
					}, specialtyBases);
				});
				this.languages = result.languages.map(language => ({
					key: language.id + language.name,
					value: language.id,
					text: language.name,
				}));
				this.studyForms = result.studyForms.map(studyForm => ({
					key: studyForm.id + studyForm.form,
					value: studyForm.id,
					text: studyForm.form,
				}));
				this.accreditations = result.accreditations.map(accreditation => ({
					key: accreditation.id + accreditation.accreditationLevel,
					value: accreditation.id,
					text: accreditation.accreditationLevel,
				}));
			});
			this.setCitiesDropdown([]);
			this.setSpecialtiesBaseDropdown([]);
			this.setUiLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setUiLoadingInitial(false);
		}
	}

	setCitiesDropdown = (value: number[]) => {
		this.cities = [];
		if (value.length === 0) {
			this.cities = Array.from(this.regions.values()).flat();
		} else {
			this.regions.forEach((cities, region) => {
				if (value.includes(region.value as number))
					this.cities = this.cities.concat(cities);
			});
		}
	}

	setSpecialtiesBaseDropdown = (value: string[]) => {
		this.specialtyBases = [];
		if (value.length === 0) {
			this.specialtyBases = Array.from(this.knowledgeBranches.values()).flat();
		} else {
			this.regions.forEach((specialtyBases, knowledgeBranch) => {
				if (value.includes(knowledgeBranch.value as string))
					this.specialtyBases = this.specialtyBases.concat(specialtyBases);
			});
		}
	}
}