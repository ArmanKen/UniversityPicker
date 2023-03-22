import _ from "lodash";
import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { InstitutionParams } from "../models/queryParams";
import { Institution, InstitutionFormValues } from "../models/institution";
import { store } from "./store";

export default class InstitutionStore {
	institutions = new Map<string, Institution>();
	selectedInstitution: Institution | undefined = undefined;
	institutionLoadingInitial = false;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();
	institutionParams: InstitutionParams = {
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
			() => this.institutionParams,
			() => {
				if (this.institutions.size < 1)
					this.handleDebounceWithLoad();
				else this.handleDebounce();
				this.selectedInstitution = undefined;
			}
		)

		reaction(
			() => this.selectedInstitution,
			() => {
				if (this.selectedInstitution)
					store.specilatyStore.loadSpecialties(this.selectedInstitution.id);
				else store.specilatyStore.specialties.clear()
			}
		)
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setInstitutionLoadingInitial = (state: boolean) => this.institutionLoadingInitial = state;

	setInstitution = (institution: Institution | undefined) => this.selectedInstitution = institution;

	setNameParam = (name: string) => this.institutionParams.name = name;

	setDegreeParam = (degree: number) => this.institutionParams.degree = degree;

	setRegionsParam = (regions: number[]) => this.institutionParams.regions = regions;

	setCitiesnsParam = (cities: number[]) => this.institutionParams.cities = cities;

	setBranchBaseIdsParam = (branchBaseIds: string[]) => this.institutionParams.branchBaseIds = branchBaseIds;

	setSpecialtyBaseIdsParam = (specialtyBaseIds: string[]) => this.institutionParams.specialtyBaseIds = specialtyBaseIds;

	setOnlyBudgetParam = (onlyBudget: boolean) => this.institutionParams.onlyBudget = onlyBudget;

	setMinPriceParam = (minPrice: number) => this.institutionParams.minPrice = minPrice;

	setMaxPriceParam = (maxPrice: number) => this.institutionParams.maxPrice = maxPrice;

	setUkraineTopParam = (ukraineTop: boolean) => this.institutionParams.ukraineTop = ukraineTop;

	private getInstitution = (id: string) => this.institutions.get(id);

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		if (this.institutionParams.name) params.append('name', this.institutionParams.name);
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

	loadInstitutions = async () => {
		this.setInstitutionLoadingInitial(true);
		try {
			const result = await agent.Institutions.list(this.axiosParams);
			runInAction(() => {
				result.data.forEach(institution => {
					this.institutions.set(institution.id, institution);
				});
			});
			this.setPagination(result.pagination);
			this.setInstitutionLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setInstitutionLoadingInitial(false);
		}
	}

	loadInstitution = async (id: string) => {
		this.setInstitutionLoadingInitial(true);
		let institution = this.getInstitution(id);
		if (institution) {
			this.selectedInstitution = institution;
			return this.selectedInstitution;
		} else {
			try {
				institution = await agent.Institutions.details(id);
				runInAction(() => {
					this.selectedInstitution = institution;
				});
				this.setInstitutionLoadingInitial(false);
			} catch (error) {
				runInAction(() => {
					console.log(error);
				});
				this.setInstitutionLoadingInitial(false);
			}
		}
	}

	createInstitution = async (institution: InstitutionFormValues) => {
		this.setInstitutionLoadingInitial(true);
		try {
			await agent.Institutions.create(institution);
			this.setInstitutionLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setInstitutionLoadingInitial(false);
		}
	}

	editInstitution = async (institution: Institution) => {
		this.setInstitutionLoadingInitial(true);
		try {
			await agent.Institutions.edit(institution);
			this.setInstitutionLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setInstitutionLoadingInitial(false);
		}
	}

	deleteInstitution = async (id: string) => {
		this.setInstitutionLoadingInitial(true);
		try {
			await agent.Institutions.delete(id);
			this.institutions.delete(id);
			this.setInstitutionLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setInstitutionLoadingInitial(false);
		}
	}

	handleDebounce = _.debounce(() => {
		this.pagingParams = new PagingParams();
		runInAction(() => this.institutions.clear());
	}, 500);

	handleDebounceWithLoad = _.debounce(() => {
		this.pagingParams = new PagingParams();
		runInAction(() => this.loadInstitutions());
	}, 500);
}