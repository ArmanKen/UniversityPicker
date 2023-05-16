import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Profile } from "../models/profile";
import { University } from "../models/university";
import { Pagination, PagingParams } from "../models/pagination";
import { store } from "./store";

export default class ProfileStore {
	profileLoadingInitial = false;
	profile: Profile | undefined = undefined;
	favoriteList = new Map<string, University>();
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();

	constructor() {
		makeAutoObservable(this)
	}

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', '20');
		return params;
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setProfileLoadingInitial = (state: boolean) => this.profileLoadingInitial = state;

	setProfile = (profile: Profile) => this.profile = profile;

	loadProfile = async (username: string) => {
		this.setProfileLoadingInitial(true);
		try {
			const result = await agent.Profiles.details(username);
			this.setProfile(result);
			this.setProfileLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setProfileLoadingInitial(false);
		}
	}

	editProfile = async (profile: Profile) => {
		this.setProfileLoadingInitial(true);
		try {
			await agent.Profiles.edit(profile);
			this.setProfile(profile);
			this.setProfileLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setProfileLoadingInitial(false);
		}
	}

	loadFavoriteList = async (profile: Profile) => {
		this.setProfileLoadingInitial(true);
		try {
			const result = await agent.Profiles.favoriteList();
			runInAction(() => {
				result.data.forEach(university =>
					this.favoriteList.set(university.id, university))
			})
			this.setPagination(result.pagination);
			this.setProfileLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setProfileLoadingInitial(false);
		}
	}

	toggleFavoriteList = async (universityId: string) => {
		this.setProfileLoadingInitial(true);
		try {
			await agent.Profiles.favoriteToggle(universityId);
			runInAction(() => {
				const university = store.universityStore.selectedUniversity;
				if (university) {
					university.inFavoriteList = !university.inFavoriteList;
				}
				if (this.favoriteList.size > 0 && this.favoriteList.has(universityId))
					this.favoriteList.delete(universityId);
			})
			this.setProfileLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setProfileLoadingInitial(false);
		}
	}

	toggleGlobalAdmin = async (username: string) => {
		this.setProfileLoadingInitial(true);
		try {
			await agent.Profiles.toggleGlobalAdmin(username);
			this.setProfileLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setProfileLoadingInitial(false);
		}
	}
}