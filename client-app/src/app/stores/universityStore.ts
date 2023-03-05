import _ from "lodash";
import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { University, UniversityFormValues } from "../models/university";

export default class UniversityStore {
	universities = new Map<string, University>();
	selectedUniversity: University | undefined = undefined;
	universityLoadingInitial = false;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();
	name = '';
	region: number[] = [];
	city: number[] = [];
	degree = '';
	branchBaseId: string[] = [];
	specialtyBaseId: string[] = [];
	budgetAllowed = false;
	minPrice = 0;
	maxPrice = 0;
	ukraineTop = false;

	constructor() {
		makeAutoObservable(this);

		reaction(
			() => [this.name,
			this.degree,
			this.region,
			this.city,
			this.branchBaseId,
			this.specialtyBaseId,
			this.budgetAllowed,
			this.minPrice,
			this.maxPrice,
			this.ukraineTop],
			() => {
				if (this.universities.size < 1)
					this.handleDebounceWithLoad();
				else this.handleDebounce();
			}
		)
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setUniversityLoadingInitial = (state: boolean) => this.universityLoadingInitial = state;

	setUniversity = (university: University | undefined) =>
		this.selectedUniversity = this.selectedUniversity === university ? undefined : university;

	private getUniversity = (id: string) => this.universities.get(id);

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		if (this.name) params.append('name', this.name);
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

	changeQueryParams = (value: string | number | boolean | (string | number | boolean)[] | undefined, key: string) => {
		switch (key) {
			case 'searchString':
				this.name = value as string;
				break;
			case 'degreeSearch':
				this.degree = value as string;
				break;
			case 'regionsSearch':
				this.region = value as number[];
				break;
			case 'citiesSearch':
				this.city = value as number[];
				break;
			case 'branchesSearch':
				this.branchBaseId = value as string[];
				break;
			case 'specialtiesSearch':
				this.specialtyBaseId = value as string[];
				break;
			case 'minPriceSearch':
				this.minPrice = value as number;
				break;
			case 'maxPriceSearch':
				this.maxPrice = value as number;
				break;
			case 'budgetSearch':
				this.budgetAllowed = value as boolean;
				break;
			case 'UkraineTopSearch':
				this.ukraineTop = value as boolean;
				break;
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