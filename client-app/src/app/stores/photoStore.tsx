import { makeAutoObservable, runInAction } from "mobx";
import { Photo } from "../models/photo";
import { Pagination, PagingParams } from "../models/pagination";
import agent from "../api/agent";
import { store } from "./store";

export class PhotoStore {
	gallery = new Map<string, Photo>();
	selectedPhoto: Photo | undefined = undefined;
	photoLoadingInitial = true;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();

	constructor() {
		makeAutoObservable(this);
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setPhotoLoadingInitial = (state: boolean) => this.photoLoadingInitial = state;

	setSelectedPhoto = (photo: Photo) => this.selectedPhoto = photo;

	get axiosParams() {
		const params = new URLSearchParams();
		params.append('pageNumber', this.pagingParams.pageNumber.toString());
		params.append('pageSize', this.pagingParams.pageSize.toString());
		return params;
	}

	loadPhotos = async (higherEducationFacilityId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.listHigherEducationFacilityPhotos(this.axiosParams, higherEducationFacilityId);
			runInAction(() => {
				result.data.forEach(photo => {
					this.gallery.set(photo.id, photo);
				});
			});
			this.setPagination(result.pagination);
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	addUserPhoto = async (file: Blob) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.addUserPhoto(file);
			runInAction(() => {
				store.userStore.setImage(result.data.url)
			});
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	addHigherEducationFacilityGalleryPhoto = async (higherEducationFacilityId: string, file: Blob) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.addHigherEducationFacilityGalleryPhoto(file, higherEducationFacilityId);
			runInAction(() => {
				this.gallery.set(result.data.id, result.data);
			});
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	addHigherEducationFacilityTitlePhoto = async (higherEducationFacilityId: string, file: Blob) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.addHigherEducationFacilityTitlePhoto(file, higherEducationFacilityId);
			runInAction(() => {
				const { selectedHigherEducationFacility, higherEducationFacilities } = store.higherEducationFacilityStore;
				const higherEducationFacility = higherEducationFacilities.get(higherEducationFacilityId);
				if (higherEducationFacility)
					higherEducationFacility.titlePhoto = result.data.url;
				if (selectedHigherEducationFacility && selectedHigherEducationFacility === higherEducationFacility) {
					selectedHigherEducationFacility.titlePhoto = result.data.url;
				}
			});
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	deleteUserPhoto = async () => {
		this.setPhotoLoadingInitial(true);
		try {
			await agent.Photos.deleteUserPhoto();
			store.userStore.setImage('');
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	deleteHigherEducationFacilityTitlePhoto = async (higherEducationFacilityId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			await agent.Photos.deleteHigherEducationFacilityTitlePhoto(higherEducationFacilityId);
			runInAction(() => {
				var higherEducationFacility = store.higherEducationFacilityStore.higherEducationFacilities.get(higherEducationFacilityId);
				if (higherEducationFacility) higherEducationFacility.titlePhoto = '';
			})
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	deleteHigherEducationFacilityPhoto = async (higherEducationFacilityId: string, photoId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			await agent.Photos.deleteHigherEducationFacilityPhoto(higherEducationFacilityId, photoId);
			runInAction(() => {
				this.gallery.delete(photoId);
			})
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}
}
