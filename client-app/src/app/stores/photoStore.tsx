import { makeAutoObservable, runInAction } from "mobx";
import { Photo } from "../models/photo";
import { Pagination, PagingParams } from "../models/pagination";
import agent from "../api/agent";
import { store } from "./store";

export class PhotoStore {
	gallery = new Map<string, Photo>();
	selectedPhoto: Photo | undefined = undefined;
	photoLoadingInitial = false;
	pagination: Pagination | undefined = undefined;
	pagingParams = new PagingParams();

	constructor() {
		makeAutoObservable(this);
	}

	setPagingParams = (pagingParams: PagingParams) => this.pagingParams = pagingParams;

	setPagination = (pagination: Pagination) => this.pagination = pagination;

	setPhotoLoadingInitial = (state: boolean) => this.photoLoadingInitial = state;

	setSelectedPhoto = (photo: Photo) => this.selectedPhoto = photo;

	clearGallery = () => this.gallery.clear();

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
				store.userStore.setImage(result.data.url);
				store.profileStore.setProfilePhoto(result.data);
			});
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	addHigherEducationFacilityGalleryPhoto = async (file: Blob) => {
		this.setPhotoLoadingInitial(true);
		try {
			if (store.higherEducationFacilityStore.selectedHigherEducationFacility) {
				const result = await agent.Photos.addHigherEducationFacilityGalleryPhoto(file, store.higherEducationFacilityStore.selectedHigherEducationFacility.id);
				runInAction(() => {
					this.gallery.set(result.data.id, result.data);
				});
			}
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	addHigherEducationFacilityTitlePhoto = async (file: Blob) => {
		this.setPhotoLoadingInitial(true);
		try {
			if (store.higherEducationFacilityStore.selectedHigherEducationFacility) {
				const result = await agent.Photos.addHigherEducationFacilityTitlePhoto(file, store.higherEducationFacilityStore.selectedHigherEducationFacility.id);
				runInAction(() => {
					const { selectedHigherEducationFacility, higherEducationFacilities } = store.higherEducationFacilityStore;
					if (store.higherEducationFacilityStore.selectedHigherEducationFacility) {
						const higherEducationFacility = higherEducationFacilities.get(store.higherEducationFacilityStore.selectedHigherEducationFacility.id);
						if (higherEducationFacility)
							higherEducationFacility.titlePhoto = result.data.url;
						if (selectedHigherEducationFacility && selectedHigherEducationFacility === higherEducationFacility) {
							selectedHigherEducationFacility.titlePhoto = result.data.url;
						}
					}
				});
			}
			this.setPhotoLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setPhotoLoadingInitial(false);
		}
	}

	addFacultyPhoto = async (higherEducationFacilityId: string, file: Blob, facultyId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			const result = await agent.Photos.addFacultyPhoto(file, higherEducationFacilityId, facultyId);
			runInAction(() => {
				const { selectedFaculty } = store.facultyStore;
				if (selectedFaculty)
					selectedFaculty.facultyPhoto = result.data;
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

	deletePhoto = async (higherEducationFacilityId: string, photoId: string) => {
		this.setPhotoLoadingInitial(true);
		try {
			await agent.Photos.deletePhoto(higherEducationFacilityId, photoId);
			runInAction(() => {
				const { selectedFaculty } = store.facultyStore;
				if (selectedFaculty && selectedFaculty.facultyPhoto.id === photoId) {
					selectedFaculty.facultyPhoto.url = '';
					selectedFaculty.facultyPhoto.id = '';
				}
				else this.gallery.delete(photoId);

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
