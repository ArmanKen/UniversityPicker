import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { Specialty } from "../models/specialty";
import { store } from "./store";

export default class SpecilatyStore {
	specialties = new Map<string, Specialty>();
	specialtyLoadingInitial = false;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();
	specialtyBaseId = '';
	specialtyName = '';

	constructor() {
		makeAutoObservable(this);
	}

	//TODO: URL,Modal specialties,filters values,navbar,

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		// if (this.region) params.append('region', this.region);
		// if (this.city) params.append('city', this.city);
		return params;
	}

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setSpecialtyLoadingInitial = (state: boolean) => this.specialtyLoadingInitial = state;

	loadSpecialties = async (id: string) => {
		try {
			if (!id) return;
			const result = await agent.Specialties.list(this.axiosParams, id);
			runInAction(() => {
				result.data.forEach(specialty => {
					this.specialties.set(specialty.id, specialty);
				});
			});
			this.setPagination(result.pagination);
			this.setSpecialtyLoadingInitial(false);
		} catch (error) {
			console.log(error);
		}
	}
}