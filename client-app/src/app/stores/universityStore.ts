import _ from "lodash";
import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { University, UniversityFormValues, UniversityQueryParams } from "../models/university";
import { store } from "./store";

export default class UniversityStore {
	universities = new Map<string, University>();
	selectedUniversity: University | undefined = undefined;
	universityLoadingInitial = false;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();
	universityQueryParams: UniversityQueryParams = {
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
				this.universityQueryParams.name,
				this.universityQueryParams.accreditationId,
				this.universityQueryParams.regionsId,
				this.universityQueryParams.citiesId,
				this.universityQueryParams.knowledgeBranchesId,
				this.universityQueryParams.specialtyBasesId,
				this.universityQueryParams.budget,
				this.universityQueryParams.ukraineTop,
				this.universityQueryParams.minPrice,
				this.universityQueryParams.maxPrice,
				this.universityQueryParams.degreeId,
			],
			() => {
				if (this.universities.size < 1)
					this.handleDebounceWithLoad();
				else this.handleDebounce();
				this.selectedUniversity = undefined;
			}
		);

		reaction(
			() => this.selectedUniversity,
			() => {
				if (this.selectedUniversity)
					store.specilatyStore.loadSpecialties(this.selectedUniversity.id);
				else store.specilatyStore.specialties.clear()
			}
		);

		reaction(
			() => this.universityQueryParams.regionsId,
			() => {
				store.uiStore.setCitiesDropdown(this.universityQueryParams.regionsId);
			}
		);

		reaction(
			() => this.universityQueryParams.knowledgeBranchesId,
			() => {
				store.uiStore.setSpecialtiesBaseDropdown(this.universityQueryParams.knowledgeBranchesId);
			}
		);
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setUniversityLoadingInitial = (state: boolean) => this.universityLoadingInitial = state;

	setUniversity = (university: University | undefined) => this.selectedUniversity = university;

	private getUniversity = (id: string) => this.universities.get(id);

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		if (this.universityQueryParams.name) params.append('name', this.universityQueryParams.name);
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