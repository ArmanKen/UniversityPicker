import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { store } from "../stores/store";
import { HigherEducationFacility, HigherEducationFacilityFormValues } from "../models/higherEducationFacility";
import { PaginatedResult } from "../models/pagination";
import { Specialty, SpecialtyFormValues } from "../models/specialty";
import { EduComponent, EduComponentFormValues } from "../models/eduComponent";
import { Profile, ProfileFormValues } from "../models/profile";
import { Photo } from "../models/photo";
import { Faculty, FacultyFormValues } from "../models/faculty";
import { Review, ReviewFormValues } from "../models/review";
import { DropdownValues } from "../models/dropdownValues";
import { router } from "../../features/routes/Router";
import { User, UserFormValues } from "../models/user";

axios.defaults.baseURL = 'http://localhost:5000/api'

axios.interceptors.request.use(config => {
	const token = store.commonStore.token;
	if (token && config.headers) config.headers.Authorization = `Bearer ${token}`;
	return config;
})

axios.interceptors.response.use(async response => {
	const pagination = response.headers['pagination'];
	if (pagination) {
		response.data = new PaginatedResult(response.data, JSON.parse(pagination));
		return response as AxiosResponse<PaginatedResult<any>>;
	}
	return response;
}, (error: AxiosError) => {
	const { data, status, config }: { data: any; status: number, config: AxiosRequestConfig } = error.response!;

	switch (status) {
		case 400:
			if (typeof data === 'string') {
				toast.error(data);
			}
			if (config.method === 'get' && data.errors.hasOwnProperty('id')) {
				router.navigate('/not-found');
			}
			if (data.errors) {
				const modalStateErrors = [];
				for (const key in data.errors) {
					if (data.errors[key]) {
						modalStateErrors.push(data.errors[key])
					}
				}
				throw modalStateErrors;
			}
			break;
		case 401:
			toast.error('unauthorized');
			break;
		case 403:
			break;
		case 404:
			router.navigate('/not-found');
			break;
		case 500:
			store.commonStore.setServerError(data);
			router.navigate('/server-error');
			break;
	}
	return Promise.reject(error);
});

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
	get: <T>(url: string) => axios.get<T>(url).then(responseBody),
	post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
	put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
	delete: <T>(url: string) => axios.delete<T>(url).then(responseBody)
}

const HigherEducationFacilities = {
	list: (params: URLSearchParams) =>
		axios.get<PaginatedResult<HigherEducationFacility[]>>('/higherEducationFacilities/list',
			{ params }).then(responseBody),
	details: (higherEducationFacilityId: string) =>
		requests.get<HigherEducationFacility>(`/higherEducationFacilities/${higherEducationFacilityId}`),
	create: (higherEducationFacility: HigherEducationFacilityFormValues) =>
		requests.post<void>(`/higherEducationFacilities/create`, higherEducationFacility),
	edit: (higherEducationFacility: HigherEducationFacilityFormValues) =>
		requests.put<void>(`/higherEducationFacilities/${higherEducationFacility.id}`, higherEducationFacility),
	delete: (higherEducationFacilityId: string) =>
		requests.delete<void>(`/higherEducationFacilities/${higherEducationFacilityId}`),
	updateLocalAdmin: (higherEducationFacilityId: string, username: string) =>
		requests.post<void>(`/higherEducationFacilities/${higherEducationFacilityId}/updateLocalAdmin/${username}`, {})
}

const Faculties = {
	list: (higherEducationFacilityId: string) =>
		requests.get<Faculty[]>(`/faculties/list/${higherEducationFacilityId}`),
	details: (facultyId: string) =>
		requests.get<Faculty>(`/faculties/${facultyId}`),
	create: (higherEducationFacilityId: string, faculty: FacultyFormValues) =>
		requests.post<void>(`/faculties/create/${higherEducationFacilityId}`, faculty),
	edit: (higherEducationFacilityId: string, faculty: FacultyFormValues) =>
		requests.put<void>(`${higherEducationFacilityId}/faculties/${faculty.id}`, faculty),
	delete: (higherEducationFacilityId: string, facultyId: string) =>
		requests.delete<void>(`${higherEducationFacilityId}/faculties/${facultyId}`),
}

const Specialties = {
	list: (facultyId: string) =>
		requests.get<Specialty[]>(`/specialties/list/${facultyId}`),
	details: (specialtyId: string) =>
		requests.get<Specialty>(`/specialties/${specialtyId}`),
	create: (higherEducationFacilityId: string, facultyId: string, specialty: SpecialtyFormValues) =>
		requests.post<void>(`${higherEducationFacilityId}/specialties/create/${facultyId}`, specialty),
	edit: (higherEducationFacilityId: string, specialty: SpecialtyFormValues, specialtyId: string) =>
		requests.put<void>(`${higherEducationFacilityId}/specialties/${specialtyId}`, specialty),
	delete: (higherEducationFacilityId: string, specialtyId: string) =>
		requests.delete<void>(`${higherEducationFacilityId}/specialties/${specialtyId}`),
}

const EduComponents = {
	list: (specialtyId: string) =>
		requests.get<EduComponent[]>(`/eduComponents/list/${specialtyId}`),
	create: (higherEducationFacilityId: string, specialtyId: string, eduComponent: EduComponentFormValues) =>
		requests.post<void>(`${higherEducationFacilityId}/eduComponents/create/${specialtyId}`, eduComponent),
	edit: (higherEducationFacilityId: string, eduComponent: EduComponentFormValues, eduComponentId: string) =>
		requests.put<void>(`${higherEducationFacilityId}/eduComponents/${eduComponentId}`, eduComponent),
	delete: (higherEducationFacilityId: string, eduComponentId: string) =>
		requests.delete<void>(`${higherEducationFacilityId}/eduComponents/${eduComponentId}`),
}

const UI = {
	list: () =>
		requests.get<DropdownValues>(`/UI/list`)
}

const Reviews = {
	list: (params: URLSearchParams, higherEducationFacilityId: string) =>
		axios.get<PaginatedResult<Review[]>>(`/reviews/list/${higherEducationFacilityId}`,
			{ params }).then(responseBody),
	details: (reviewId: string) =>
		requests.get<Review>(`/reviews/${reviewId}`),
	userReview: (higherEducationFacilityId: string) =>
		requests.get<Review>(`/reviews/user/${higherEducationFacilityId}`),
	create: (higherEducationFacilityId: string, review: ReviewFormValues) =>
		requests.post<void>(`/reviews/create/${higherEducationFacilityId}`, review),
	edit: (higherEducationFacilityId: string, review: ReviewFormValues, reviewId: string) =>
		requests.put<void>(`/reviews/${higherEducationFacilityId}/${reviewId}`, review),
	delete: (higherEducationFacilityId: string, reviewId: string) =>
		requests.delete<void>(`/reviews/${higherEducationFacilityId}/${reviewId}`),
}

const Account = {
	current: () => requests.get<User>('/account'),
	login: (user: UserFormValues) => requests.post<User>('/account/login', user),
	register: (user: UserFormValues) => requests.post<User>('/account/register', user),
	isGlobalAdmin: () => requests.get<boolean>('/account/isGlobalAdmin'),
	isLocalAdmin: (higherEducationFacilityId: string) => requests.get<boolean>(`/account/isLocalAdmin/${higherEducationFacilityId}`),
}

const Profiles = {
	details: (username: string) =>
		requests.get<Profile>(`/profiles/${username}`),
	edit: (profile: ProfileFormValues) =>
		requests.put<void>(`/profiles/update`, profile),
	favoriteList: () =>
		requests.get<PaginatedResult<HigherEducationFacility[]>>('/profiles/favoriteList'),
	favoriteToggle: (higherEducationFacilityId: string) =>
		requests.put<void>(`/profiles/favoriteToggle/${higherEducationFacilityId}`, higherEducationFacilityId),
	toggleGlobalAdmin: (username: string) =>
		requests.put<void>(`/profiles/admin/${username}`, username)
}

const Photos = {
	listHigherEducationFacilityPhotos: (params: URLSearchParams, higherEducationFacilityId: string) =>
		axios.get<PaginatedResult<Photo[]>>(`/photos/${higherEducationFacilityId}/gallery`,
			{ params }).then(responseBody),
	addFacultyPhoto: (file: Blob, higherEducationFacilityId: string, facultyId: string) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>(`photos/${higherEducationFacilityId}/${facultyId}`, formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	addUserPhoto: (file: Blob) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>('photos/user/add', formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	addHigherEducationFacilityGalleryPhoto: (file: Blob, higherEducationFacilityId: string) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>(`photos/${higherEducationFacilityId}/gallery`, formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	addHigherEducationFacilityTitlePhoto: (file: Blob, higherEducationFacilityId: string) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>(`photos/${higherEducationFacilityId}/titleImage`, formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	deleteUserPhoto: () =>
		requests.delete<void>(`photos/`),
	deletePhoto: (higherEducationFacilityId: string, photoId: string) =>
		requests.delete<void>(`photos/${higherEducationFacilityId}/${photoId}`),
	deleteHigherEducationFacilityTitlePhoto: (higherEducationFacilityId: string) =>
		requests.delete<void>(`photos/${higherEducationFacilityId}`)
}

const agent = {
	HigherEducationFacilities,
	Faculties,
	Specialties,
	EduComponents,
	UI,
	Account,
	Profiles,
	Photos,
	Reviews
}

export default agent;