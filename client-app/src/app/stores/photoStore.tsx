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

	loadPhotos = async (universityId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.listUniversityPhotos(this.axiosParams, universityId);
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

	addUniversityGalleryPhoto = async (universityId: string, file: Blob) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.addUniversityGalleryPhoto(file, universityId);
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

	addUniversityTitlePhoto = async (universityId: string, file: Blob) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.addUniversityTitlePhoto(file, universityId);
			runInAction(() => {
				const { selectedUniversity, universities } = store.universityStore;
				const university = universities.get(universityId);
				if (university)
					university.titlePhoto = result.data.url;
				if (selectedUniversity && selectedUniversity === university) {
					selectedUniversity.titlePhoto = result.data.url;
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

	deleteUniversityTitlePhoto = async (universityId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			await agent.Photos.deleteUniversityTitlePhoto(universityId);
			runInAction(() => {
				var university = store.universityStore.universities.get(universityId);
				if (university) university.titlePhoto = '';
			})
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	deleteUniversityPhoto = async (universityId: string, photoId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			await agent.Photos.deleteUniversityPhoto(universityId, photoId);
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
