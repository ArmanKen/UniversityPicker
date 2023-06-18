import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Profile, ProfileFormValues } from "../models/profile";
import { HigherEducationFacility } from "../models/higherEducationFacility";
import { Pagination, PagingParams } from "../models/pagination";
import { store } from "./store";
import { Photo } from "../models/photo";

export default class ProfileStore {
	profileLoadingInitial = false;
	favoriteListLoadingInitial = false;
	activeTab = 0;
	profile: Profile | undefined = undefined;
	favoriteList = new Map<string, HigherEducationFacility>();
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

	get isCurrentUser() {
		if (store.userStore.user && this.profile)
			return store.userStore.user.username === this.profile.username;
		return false;
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setProfileLoadingInitial = (state: boolean) => this.profileLoadingInitial = state;

	setFavoriteListLoadingInitial = (state: boolean) => this.favoriteListLoadingInitial = state;

	setProfile = (profile: Profile) => this.profile = profile;

	setActiveTab = (activeTab: any) => {
		this.activeTab = activeTab;
	}

	setProfilePhoto = (photo: Photo) => {
		if (this.profile) this.profile.photo = photo;
	}

	clearProfile = () => {
		this.profile = undefined;
		this.favoriteList.clear();
	}

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

	editProfile = async (profile: ProfileFormValues) => {
		this.setProfileLoadingInitial(true);
		try {
			await agent.Profiles.edit(profile);
			if (this.profile) {
				if (profile.fullName && profile.fullName !== store.userStore.user?.fullName) {
					store.userStore.setDisplayName(profile.fullName);
					this.profile.fullName = profile.fullName;
				}
				this.profile.bio = profile.bio;
			}
			this.setProfileLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setProfileLoadingInitial(false);
		}
	}

	loadFavoriteList = async () => {
		this.setFavoriteListLoadingInitial(true);
		try {
			const result = await agent.Profiles.favoriteList();
			runInAction(() => {
				result.data.forEach(higherEducationFacility =>
					this.favoriteList.set(higherEducationFacility.id, higherEducationFacility))
			})
			this.setPagination(result.pagination);
			this.setFavoriteListLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setFavoriteListLoadingInitial(false);
		}
	}

	toggleFavoriteList = async (higherEducationFacilityId: string) => {
		this.setFavoriteListLoadingInitial(true);
		try {
			await agent.Profiles.favoriteToggle(higherEducationFacilityId);
			runInAction(() => {
				const higherEducationFacility = store.higherEducationFacilityStore.selectedHigherEducationFacility;
				if (higherEducationFacility) {
					higherEducationFacility.inFavoriteList = !higherEducationFacility.inFavoriteList;
				}
				if (this.favoriteList.size > 0 && this.favoriteList.has(higherEducationFacilityId))
					this.favoriteList.delete(higherEducationFacilityId);
			})
			this.setFavoriteListLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setFavoriteListLoadingInitial(false);
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