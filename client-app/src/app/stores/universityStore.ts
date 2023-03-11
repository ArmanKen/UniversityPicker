import _ from "lodash";
import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { UniversityParams } from "../models/queryParams";
import { University, UniversityFormValues } from "../models/university";
import { store } from "./store";

export default class UniversityStore {
	universities = new Map<string, University>();
	selectedUniversity: University | undefined = undefined;
	universityLoadingInitial = false;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();
	universityParams: UniversityParams = {
		name: '',
		regions: [],
		cities: [],
		degree: 0,
		branchBaseIds: [],
		specialtyBaseIds: [],
		onlyBudget: false,
		minPrice: 0,
		maxPrice: 0,
		ukraineTop: false
	}

	constructor() {
		makeAutoObservable(this);

		reaction(
			() => this.universityParams,
			() => {
				if (this.universities.size < 1)
					this.handleDebounceWithLoad();
				else this.handleDebounce();
				this.selectedUniversity = undefined;
			}
		)

		reaction(
			() => this.selectedUniversity,
			() => {
				if (this.selectedUniversity)
					store.specilatyStore.loadSpecialties(this.selectedUniversity.id);
				else store.specilatyStore.specialties.clear()
			}
		)
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setUniversityLoadingInitial = (state: boolean) => this.universityLoadingInitial = state;

	setUniversity = (university: University | undefined) => this.selectedUniversity = university;

	setNameParam = (name: string) => this.universityParams.name = name;

	setDegreeParam = (degree: number) => this.universityParams.degree = degree;

	setRegionsParam = (regions: number[]) => this.universityParams.regions = regions;

	setCitiesnsParam = (cities: number[]) => this.universityParams.cities = cities;

	setBranchBaseIdsParam = (branchBaseIds: string[]) => this.universityParams.branchBaseIds = branchBaseIds;

	setSpecialtyBaseIdsParam = (specialtyBaseIds: string[]) => this.universityParams.specialtyBaseIds = specialtyBaseIds;

	setOnlyBudgetParam = (onlyBudget: boolean) => this.universityParams.onlyBudget = onlyBudget;

	setMinPriceParam = (minPrice: number) => this.universityParams.minPrice = minPrice;

	setMaxPriceParam = (maxPrice: number) => this.universityParams.maxPrice = maxPrice;

	setUkraineTopParam = (ukraineTop: boolean) => this.universityParams.ukraineTop = ukraineTop;

	private getUniversity = (id: string) => this.universities.get(id);

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		if (this.universityParams.name) params.append('name', this.universityParams.name);
		// if (this.region) params.append('region', this.region);
		// if (this.city) params.append('city', this.city);
		// if (this.degree) params.append('degree', this.degree);
		// if (this.branchBaseId) params.append('branchBaseId', this.branchBaseId);
		// if (this.specialtyBaseId) params.append('specialtyBaseId', this.specialtyBaseId);
		// if (this.budgetAllowed) params.append('budgetAllowed', this.budgetAllowed.toString());
		// if (this.minPrice) params.append('minPrice', this.minPrice.toString());
		// if (this.maxPrice) params.append('maxPrice', this.maxPrice.toString());
		// if (this.ukraineTop) params.append('ukraineTop', this.ukraineTop.toString());
		return params;
	}

	loadUniversities = async () => {
		this.setUniversityLoadingInitial(true);
		try {
			const result = await agent.Universities.list(this.axiosParams);
			runInAction(() => {
				result.data.forEach(university => {
					this.universities.set(university.id, university);
				});
			});
			this.setPagination(result.pagination);
			this.setUniversityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setUniversityLoadingInitial(false);
		}
	}

	loadUniversity = async (id: string) => {
		this.setUniversityLoadingInitial(true);
		let university = this.getUniversity(id);
		if (university) {
			this.selectedUniversity = university;
			return this.selectedUniversity;
		} else {
			try {
				university = await agent.Universities.details(id);
				runInAction(() => {
					this.selectedUniversity = university;
				});
				this.setUniversityLoadingInitial(false);
			} catch (error) {
				runInAction(() => {
					console.log(error);
				});
				this.setUniversityLoadingInitial(false);
			}
		}
	}

	createUniversity = async (university: UniversityFormValues) => {
		this.setUniversityLoadingInitial(true);
		try {
			await agent.Universities.create(university);
			this.setUniversityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setUniversityLoadingInitial(false);
		}
	}

	editUniversity = async (university: University) => {
		this.setUniversityLoadingInitial(true);
		try {
			await agent.Universities.edit(university);
			this.setUniversityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setUniversityLoadingInitial(false);
		}
	}

	deleteUniversity = async (id: string) => {
		this.setUniversityLoadingInitial(true);
		try {
			await agent.Universities.delete(id);
			this.universities.delete(id);
			this.setUniversityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setUniversityLoadingInitial(false);
		}
	}

	handleDebounce = _.debounce(() => {
		this.pagingParams = new PagingParams();
		runInAction(() => this.universities.clear());
	}, 500);

	handleDebounceWithLoad = _.debounce(() => {
		this.pagingParams = new PagingParams();
		runInAction(() => this.loadUniversities());
	}, 500);
}