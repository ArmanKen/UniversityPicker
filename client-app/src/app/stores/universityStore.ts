import _ from "lodash";
import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { HigherEducationFacility, HigherEducationFacilityFormValues, HigherEducationFacilityQueryParams } from "../models/higherEducationFacility";
import { store } from "./store";

export default class HigherEducationFacilityStore {
	higherEducationFacilities = new Map<string, HigherEducationFacility>();
	selectedHigherEducationFacility: HigherEducationFacility | undefined = undefined;
	higherEducationFacilityLoadingInitial = true;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();
	higherEducationFacilityQueryParams: HigherEducationFacilityQueryParams = {
		name: '',
		accreditationId: 0,
		regionsId: [],
		citiesId: [],
		degreeId: 0,
		knowledgeBranchesId: [],
		specialtyBasesId: [],
		budget: false,
		minPrice: 0,
		maxPrice: 0,
		ukraineTop: false
	}

	constructor() {
		makeAutoObservable(this);

		reaction(
			() => [
				this.higherEducationFacilityQueryParams.name,
				this.higherEducationFacilityQueryParams.accreditationId,
				this.higherEducationFacilityQueryParams.regionsId,
				this.higherEducationFacilityQueryParams.citiesId,
				this.higherEducationFacilityQueryParams.knowledgeBranchesId,
				this.higherEducationFacilityQueryParams.specialtyBasesId,
				this.higherEducationFacilityQueryParams.budget,
				this.higherEducationFacilityQueryParams.ukraineTop,
				this.higherEducationFacilityQueryParams.minPrice,
				this.higherEducationFacilityQueryParams.maxPrice,
				this.higherEducationFacilityQueryParams.degreeId,
			],
			() => {
				if (this.higherEducationFacilities.size < 1)
					this.handleDebounceWithLoad();
				else this.handleDebounce();
			}
		);

		reaction(
			() => this.higherEducationFacilityQueryParams.regionsId,
			() => {
				store.uiStore.setCitiesDropdown(this.higherEducationFacilityQueryParams.regionsId);
			}
		);

		reaction(
			() => this.higherEducationFacilityQueryParams.knowledgeBranchesId,
			() => {
				store.uiStore.setSpecialtiesBaseDropdown(this.higherEducationFacilityQueryParams.knowledgeBranchesId);
			}
		);
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setHigherEducationFacilityLoadingInitial = (state: boolean) => this.higherEducationFacilityLoadingInitial = state;

	setHigherEducationFacility = (higherEducationFacility: HigherEducationFacility) => this.selectedHigherEducationFacility = higherEducationFacility;

	clearHigherEducationFacilites = () => this.higherEducationFacilities.clear();

	clearHigherEducationFacility = () => {
		this.selectedHigherEducationFacility = undefined;
		store.facultyStore.faculties.clear();
	}

	private getHigherEducationFacility = (higherEducationFacilityId: string) => this.higherEducationFacilities.get(higherEducationFacilityId);

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', '20');
		const higherEducationFacilityParams = this.higherEducationFacilityQueryParams;
		if (higherEducationFacilityParams.name) params.append('name', higherEducationFacilityParams.name);
		if (higherEducationFacilityParams.regionsId.length) params.append('regionsId', higherEducationFacilityParams.regionsId.join("_"));
		if (higherEducationFacilityParams.citiesId.length) params.append('citiesId', higherEducationFacilityParams.citiesId.join("_"));
		if (higherEducationFacilityParams.degreeId) params.append('degreeId', higherEducationFacilityParams.degreeId.toString());
		if (higherEducationFacilityParams.knowledgeBranchesId.length) params.append('knowledgeBranchesId', higherEducationFacilityParams.knowledgeBranchesId.join("_"));
		if (higherEducationFacilityParams.specialtyBasesId.length) params.append('specialtyBasesId', higherEducationFacilityParams.specialtyBasesId.join("_"));
		if (higherEducationFacilityParams.budget) params.append('budget', higherEducationFacilityParams.budget.toString());
		if (higherEducationFacilityParams.minPrice) params.append('minPrice', higherEducationFacilityParams.minPrice.toString());
		if (higherEducationFacilityParams.maxPrice) params.append('maxPrice', higherEducationFacilityParams.maxPrice.toString());
		if (higherEducationFacilityParams.ukraineTop) params.append('ukraineTop', higherEducationFacilityParams.ukraineTop.toString());
		return params;
	}

	loadHigherEducationFacilites = async () => {
		this.setHigherEducationFacilityLoadingInitial(true);
		try {
			const result = await agent.HigherEducationFacilities.list(this.axiosParams);
			runInAction(() => {
				result.data.forEach(higherEducationFacility => {
					this.higherEducationFacilities.set(higherEducationFacility.id, higherEducationFacility);
				});
			});
			this.setPagination(result.pagination);
			this.setHigherEducationFacilityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setHigherEducationFacilityLoadingInitial(false);
		}
	}

	loadHigherEducationFacility = async (higherEducationFacilityId: string) => {
		this.setHigherEducationFacilityLoadingInitial(true);
		this.clearHigherEducationFacility();
		let higherEducationFacility = this.getHigherEducationFacility(higherEducationFacilityId);
		if (higherEducationFacility) {
			this.selectedHigherEducationFacility = higherEducationFacility;
			this.setHigherEducationFacilityLoadingInitial(false);
			return this.selectedHigherEducationFacility;
		} else {
			try {
				higherEducationFacility = await agent.HigherEducationFacilities.details(higherEducationFacilityId);
				this.setHigherEducationFacility(higherEducationFacility);
				this.setHigherEducationFacilityLoadingInitial(false);
			} catch (error) {
				runInAction(() => {
					console.log(error);
				});
				this.setHigherEducationFacilityLoadingInitial(false);
			}
		}
	}

	createHigherEducationFacility = async (higherEducationFacility: HigherEducationFacilityFormValues) => {
		this.setHigherEducationFacilityLoadingInitial(true);
		try {
			await agent.HigherEducationFacilities.create(higherEducationFacility);
			this.setHigherEducationFacilityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setHigherEducationFacilityLoadingInitial(false);
		}
	}

	editHigherEducationFacility = async (higherEducationFacility: HigherEducationFacility) => {
		this.setHigherEducationFacilityLoadingInitial(true);
		try {
			await agent.HigherEducationFacilities.edit(higherEducationFacility);
			this.setHigherEducationFacilityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setHigherEducationFacilityLoadingInitial(false);
		}
	}

	deleteHigherEducationFacility = async (higherEducationFacilityId: string) => {
		this.setHigherEducationFacilityLoadingInitial(true);
		try {
			await agent.HigherEducationFacilities.delete(higherEducationFacilityId);
			this.higherEducationFacilities.delete(higherEducationFacilityId);
			this.setHigherEducationFacilityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setHigherEducationFacilityLoadingInitial(false);
		}
	}

	handleDebounce = _.debounce(() => {
		this.setPagingParams(new PagingParams(1, 20));
		this.clearHigherEducationFacilites();
	}, 500);

	handleDebounceWithLoad = _.debounce(() => {
		this.setPagingParams(new PagingParams(1, 20));
		this.loadHigherEducationFacilites();
	}, 500);
}