import { makeAutoObservable, runInAction } from "mobx";
import { DropdownItemProps } from "semantic-ui-react";
import agent from "../api/agent";
import { BranchesOfKnowledge } from "../common/commonData/branchesList";
import { City, Region } from "../models/region";
import { SpecialtyBase } from "../models/specialty";
import { store } from "./store";

export default class MenuStore {
	menuLoadingInitial = false;
	regions = new Map<number, Region>();
	cities = new Map<City, number>();
	specialtiesBase = new Map<SpecialtyBase, string>();
	degreeDropdown: DropdownItemProps[] = [];
	regionsDropdown: DropdownItemProps[] = [];
	citiesDropdown: DropdownItemProps[] = [];
	branchesOfKnowlegdeDropdown: DropdownItemProps[] = [];
	specialtiesBaseDropdown: DropdownItemProps[] = [];
	selectedCities: number[] = [];
	selectedSpecialtiesBase: string[] = [];

	constructor() {
		makeAutoObservable(this);
		this.branchesOfKnowlegdeDropdown = BranchesOfKnowledge;
	}

	setMenuLoadingInitial = (state: boolean) => this.menuLoadingInitial = state;

	setSelectedCities = (value: number[]) => this.selectedCities = value;

	setSelectedSpecialtiesBase = (value: string[]) => this.selectedSpecialtiesBase = value;

	loadRegions = async () => {
		this.setMenuLoadingInitial(true);
		try {
			const result = await agent.Menus.regionsList();
			runInAction(() => {
				result.forEach(region => {
					this.regions.set(region.id, region);
					this.regionsDropdown.push({
						key: region.id + region.name,
						text: region.name,
						value: region.id
					});
					region.cities.forEach(city => {
						this.cities.set(city, region.id);
						this.citiesDropdown.push({
							key: city.name + city.id,
							text: city.name + ', ' + region.name,
							value: city.id
						});
					});
				});
			});
			this.setMenuLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setMenuLoadingInitial(false);
		}
	}

	loadSpecialtiesBase = async () => {
		this.setMenuLoadingInitial(true);
		try {
			const result = await agent.Menus.specialtyBasesList();
			runInAction(() => {
				result.forEach(specialtyBase => {
					this.specialtiesBase.set(specialtyBase, specialtyBase.id.slice(0, 2));
					this.specialtiesBaseDropdown.push(
						{
							key: specialtyBase.id,
							text: specialtyBase.name,
							value: specialtyBase.id
						});
				});
			});
			this.setMenuLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setMenuLoadingInitial(false);
		}
	}

	loadDegrees = async () => {
		this.setMenuLoadingInitial(true);
		try {
			const result = await agent.Menus.degreesList();
			runInAction(() => {
				result.forEach(degree => {
					this.degreeDropdown.push(
						{
							key: degree.name,
							text: degree.name,
							value: degree.id
						});
				});
			});
			this.setMenuLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setMenuLoadingInitial(false);
		}
	}

	setCitiesDropdown = (value: number[]) => {
		if (value.length !== 0) {
			store.institutionStore.institutionParams.cities = [];
			this.selectedCities = [];
		}
		this.citiesDropdown.length = 0;
		this.cities.forEach((regionId, city) => {
			if (value.length === 0 || value.find((value) => regionId === value))
				this.citiesDropdown.push({
					key: city.name + city.id,
					text: city.name + ", " + this.regions.get(regionId)?.name,
					value: city.id
				});
		})
	}

	setSpecialtiesBaseDropdown = (value: string[]) => {
		if (value.length !== 0) {
			store.institutionStore.institutionParams.specialtyBaseIds = [];
			this.selectedSpecialtiesBase = [];
		}
		this.specialtiesBaseDropdown.length = 0;
		this.specialtiesBase.forEach((id, specialtyBase) => {
			if (value.length === 0 || value.find((value) => id === value))
				this.specialtiesBaseDropdown.push({
					key: specialtyBase.name + specialtyBase.id,
					text: specialtyBase.name,
					value: specialtyBase.id
				});
		})
	}
}