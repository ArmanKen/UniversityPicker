import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, UniversityParams, PagingParams } from "../models/pagination";
import { University, UniversityFormValues } from "../models/university";

export default class UniversityStore {
	universities = new Map<string, University>;
	selectedUniversity: University | undefined = undefined;
	loadingInitial = false;
	loading = false;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();
	queryParams = new UniversityParams();

	constructor() {
		makeAutoObservable(this);

		// reaction(
		// 	() => { this.queryParams },
		// 	() => {
		// 		this.pagingParams = new PagingParams();
		// 		this.universities.clear();
		// 		this.loadUniversities();
		// 	}
		// )
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setLoadingInitial = (state: boolean) => this.loadingInitial = state;

	setLoading = (state: boolean) => this.loading = state;

	setSelectedUniversity = (university: University | undefined) =>
		this.selectedUniversity = this.selectedUniversity == university ? undefined : university;

	private getUniversity = (id: string) => this.universities.get(id);

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		if (this.queryParams.name) params.append('name', this.queryParams.name);
		if (this.queryParams.region) params.append('region', this.queryParams.region.name);
		if (this.queryParams.city) params.append('city', this.queryParams.city.name);
		if (this.queryParams.degree) params.append('degree', this.queryParams.degree);
		if (this.queryParams.branchBaseId) params.append('branchBaseId', this.queryParams.branchBaseId);
		if (this.queryParams.specialtyBaseId) params.append('specialtyBaseId', this.queryParams.specialtyBaseId);
		if (this.queryParams.budgetAllowed) params.append('budgetAllowed', this.queryParams.budgetAllowed.toString());
		if (this.queryParams.minPrice) params.append('minPrice', this.queryParams.minPrice.toString());
		if (this.queryParams.maxPrice) params.append('maxPrice', this.queryParams.maxPrice.toString());
		if (this.queryParams.ukraineTop) params.append('ukraineTop', this.queryParams.ukraineTop.toString());
		return params;
	}

	loadUniversities = async () => {
		if (this.universities.size < 1)
			this.setLoadingInitial(true);
		else
			this.setLoading(true);
		try {
			const result = await agent.Universities.list(this.axiosParams);
			runInAction(() => {
				result.data.forEach(university => {
					this.universities.set(university.id, university);
				})
			})
			this.setPagination(result.pagination);
			this.setLoadingInitial(false);
			this.setLoading(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
			this.setLoading(false);
		}
	}

	loadUniversity = async (id: string) => {
		this.setLoadingInitial(true);
		let university = this.getUniversity(id);
		if (university) {
			this.selectedUniversity = university;
			return this.selectedUniversity;
		} else {
			try {
				university = await agent.Universities.details(id);
				runInAction(() => {
					this.selectedUniversity = university;
				})
				this.setLoadingInitial(false);
			} catch (error) {
				runInAction(() => {
					console.log(error);
				})
				this.setLoadingInitial(false);
			}
		}
	}

	createUniversity = async (university: UniversityFormValues) => {
		this.setLoadingInitial(true);
		try {
			await agent.Universities.create(university);
			this.setLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
		}
	}

	editUniversity = async (university: University) => {
		this.setLoadingInitial(true);
		try {
			await agent.Universities.edit(university);
			this.setLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
		}
	}

	deleteUniversity = async (id: string) => {
		this.setLoadingInitial(true);
		try {
			await agent.Universities.delete(id);
			this.universities.delete(id);
			this.setLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
		}
	}
}