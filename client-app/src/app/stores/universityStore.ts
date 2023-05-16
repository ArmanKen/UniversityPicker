import _ from "lodash";
import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { University, UniversityFormValues, UniversityQueryParams } from "../models/university";
import { store } from "./store";

export default class UniversityStore {
	universities = new Map<string, University>();
	selectedUniversity: University | undefined = undefined;
	universityLoadingInitial = true;
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

	setUniversity = (university: University) => this.selectedUniversity = university;

	clearUniversities = () => this.universities.clear();

	clearUniversity = () => {
		this.selectedUniversity = undefined;
		store.facultyStore.faculties.clear();
	}

	private getUniversity = (universityId: string) => this.universities.get(universityId);

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', '20');
		const universityParams = this.universityQueryParams;
		if (universityParams.name) params.append('name', universityParams.name);
		if (universityParams.regionsId.length) params.append('regionsId', universityParams.regionsId.join("_"));
		if (universityParams.citiesId.length) params.append('citiesId', universityParams.citiesId.join("_"));
		if (universityParams.degreeId) params.append('degreeId', universityParams.degreeId.toString());
		if (universityParams.knowledgeBranchesId.length) params.append('knowledgeBranchesId', universityParams.knowledgeBranchesId.join("_"));
		if (universityParams.specialtyBasesId.length) params.append('specialtyBasesId', universityParams.specialtyBasesId.join("_"));
		if (universityParams.budget) params.append('budget', universityParams.budget.toString());
		if (universityParams.minPrice) params.append('minPrice', universityParams.minPrice.toString());
		if (universityParams.maxPrice) params.append('maxPrice', universityParams.maxPrice.toString());
		if (universityParams.ukraineTop) params.append('ukraineTop', universityParams.ukraineTop.toString());
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

	loadUniversity = async (universityId: string) => {
		this.setUniversityLoadingInitial(true);
		this.clearUniversity();
		let university = this.getUniversity(universityId);
		if (university) {
			this.selectedUniversity = university;
			this.setUniversityLoadingInitial(false);
			return this.selectedUniversity;
		} else {
			try {
				university = await agent.Universities.details(universityId);
				this.setUniversity(university);
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

	deleteUniversity = async (universityId: string) => {
		this.setUniversityLoadingInitial(true);
		try {
			await agent.Universities.delete(universityId);
			this.universities.delete(universityId);
			this.setUniversityLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setUniversityLoadingInitial(false);
		}
	}

	handleDebounce = _.debounce(() => {
		this.setPagingParams(new PagingParams(1, 20));
		this.clearUniversities();
	}, 500);

	handleDebounceWithLoad = _.debounce(() => {
		this.setPagingParams(new PagingParams(1, 20));
		this.loadUniversities();
	}, 500);
}