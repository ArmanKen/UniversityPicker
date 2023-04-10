import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { store } from "../stores/store";
import { University, UniversityFormValues } from "../models/university";
import { PaginatedResult } from "../models/pagination";
import { Specialty, SpecialtyFormValues } from "../models/specialty";
import { EduComponent, EduComponentFormValues } from "../models/eduComponent";
import { Profile } from "../models/profile";
import { Photo } from "../models/photo";
import { Faculty, FacultyFormValues } from "../models/faculty";
import { Review, ReviewFormValues } from "../models/review";
import { DropdownValues } from "../models/dropdownValues";
import { router } from "../../features/routes/Router";

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

const Universities = {
	list: (params: URLSearchParams) =>
		axios.get<PaginatedResult<University[]>>('/universities/list',
			{ params }).then(responseBody),
	details: (universityId: string) =>
		requests.get<University>(`/universities/${universityId}`),
	create: (university: UniversityFormValues) =>
		requests.post<void>(`/universities/create`, university),
	edit: (university: University) =>
		requests.put<void>(`/universities/${university.id}`, university),
	delete: (universityId: string) =>
		requests.delete<void>(`/universities/${universityId}`),
	updateLocalAdmin: (universityId: string, username: string) =>
		requests.post<void>(`/universities/${universityId}/updateLocalAdmin/${username}`, {})
}

const Faculties = {
	list: (universityId: string) =>
		requests.get<Faculty[]>(`/faculties/list/${universityId}`),
	details: (facultyId: string) =>
		requests.get<Faculty>(`/faculties/${facultyId}`),
	create: (universityId: string, faculty: FacultyFormValues) =>
		requests.post<void>(`/faculties/create/${universityId}`, faculty),
	edit: (faculty: Faculty) =>
		requests.put<void>(`/faculties/${faculty.id}`, faculty),
	delete: (facultyId: string) =>
		requests.delete<void>(`/faculties/${facultyId}`),
}

const Specialties = {
	list: (params: URLSearchParams, facultyId: string) =>
		axios.get<PaginatedResult<Specialty[]>>(`/specialties/list/${facultyId}`,
			{ params }).then(responseBody),
	details: (specialtyId: string) =>
		requests.get<Faculty>(`/specialties/${specialtyId}`),
	create: (facultyId: string, specialty: SpecialtyFormValues) =>
		requests.post<void>(`/specialties/create/${facultyId}`, specialty),
	edit: (specialty: Specialty) =>
		requests.put<void>(`/specialties/${specialty.id}`, specialty),
	delete: (specialtyId: string) =>
		requests.delete<void>(`/specialties/${specialtyId}`),
}

const EduComponents = {
	list: (specialtyId: string) =>
		requests.get<Faculty[]>(`/eduComponents/list/${specialtyId}`),
	create: (specialtyId: string, eduComponent: EduComponentFormValues) =>
		requests.post<void>(`/eduComponents/create/${specialtyId}`, eduComponent),
	edit: (eduComponent: EduComponent) =>
		requests.put<void>(`/eduComponents/${eduComponent.id}`, eduComponent),
	delete: (eduComponentId: string) =>
		requests.delete<void>(`/eduComponents/${eduComponentId}`),
}

const UI = {
	list: () =>
		requests.get<DropdownValues>(`/UI/list`)
}

const Reviews = {
	list: (params: URLSearchParams, universityId: string) =>
		axios.get<PaginatedResult<Review[]>>(`/reviews/list/${universityId}`,
			{ params }).then(responseBody),
	details: (reviewId: string) =>
		requests.get<Faculty>(`/reviews/${reviewId}`),
	create: (universityId: string, review: ReviewFormValues) =>
		requests.post<void>(`/reviews/create/${universityId}`, review),
	edit: (universityId: string, review: Review) =>
		requests.put<void>(`/reviews/${universityId}`, review),
	delete: (universityId: string) =>
		requests.delete<void>(`/reviews/${universityId}`),
}

const Profiles = {
	list: (username: string) =>
		requests.get<Profile>(`/profiles/${username}`),
	edit: (profile: Partial<Profile>) =>
		requests.put<void>(`/profiles/update`, profile),
	favoriteList: () =>
		requests.get<University[]>('/profile/favoriteList'),
	favoriteToggle: (universityId: string) =>
		requests.get<University[]>(`/profile/favoriteToggle/${universityId}`)
}

const Photos = {
	listUniversityPhotos: (id: string) =>
		requests.get<PaginatedResult<Photo[]>>(`/photos/${id}/gallery`),
	addPhoto: (file: Blob) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>('photos', formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	addUniversityGalleryPhoto: (file: Blob, universityId: string) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>(`photos/${universityId}/gallery`, formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	addUniversityTitlePhoto: (file: Blob, universityId: string) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>(`photos/${universityId}/titleImage`, formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	delete: (id: string) =>
		requests.delete<void>(`photos/${id}`)
}

const agent = {
	Universities,
	Faculties,
	Specialties,
	EduComponents,
	UI,
	Profiles,
	Photos,
	Reviews
}

export default agent;