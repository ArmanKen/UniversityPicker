import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, UniversityParams } from "../models/pagination";
import { University, UniversityFormValues } from "../models/university";

export default class UniversityStore {
	universities = new Map<string, University>;
	selectedUniversity: University | undefined = undefined;
	loadingInitial = false;
	loading = false;
	pagination: Pagination | null = null;
	pagingParams = new UniversityParams();

	constructor() {
		makeAutoObservable(this);
	}

	get axiosParams() {
		const params = new URLSearchParams(); //new params
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		return params;
	}

	private getUniversity = (id: string) => this.universities.get(id);

	loadUniversities = async () => {
		this.setLoadingInitial(true);
		try {
			const result = await agent.Universities.list(this.axiosParams);
			runInAction(() => {
				result.data.forEach(university => {
					this.universities.set(university.id, university);
				})
			})
			this.setPagination(result.pagination);
			this.setLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
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

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setLoadingInitial = (state: boolean) => this.loadingInitial = state;

	setLoading = (state: boolean) => this.loading = state;
}