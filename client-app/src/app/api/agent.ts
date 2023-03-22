import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { history } from "../..";
import { toast } from "react-toastify";
import { store } from "../stores/store";
import { Institution, InstitutionFormValues } from "../models/institution";
import { PaginatedResult } from "../models/pagination";
import { Specialty, SpecialtyBase } from "../models/specialty";
import { Discipline } from "../models/discipline";
import { Region } from "../models/region";
import { Profile } from "../models/profile";
import { Photo } from "../models/photo";
import { Degree } from "../models/degree";

const sleep = (delay: number) => {
	return new Promise((resolve) => {
		setTimeout(resolve, delay)
	})
}

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
				history.push('/not-found');
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
			history.push('/not-found')
			break;
		case 500:
			store.commonStore.setServerError(data);
			history.push('/server-error')
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

const Institutions = {
	list: (params: URLSearchParams) => axios.get<PaginatedResult<Institution[]>>('/institutions/', { params }).then(responseBody),
	details: (id: string) => requests.get<Institution>(`/institutions/${id}`),
	create: (institution: InstitutionFormValues) => requests.post<void>(`/institutions/`, institution),
	edit: (institution: Institution) => requests.put<void>(`/institutions/`, institution),
	delete: (id: string) => requests.delete<void>(`/institutions/${id}`),
	select: (id: string) => requests.post<void>(`/institutions/${id}/selectInstitution/`, {}),
	toggleLocalAdmin: (id: string, username: string) => requests.post<void>(`/institutions/${id}/localAdmin/${username}`, {})
}

const Specialties = {
	list: (params: URLSearchParams, id: string) =>
		axios.get<PaginatedResult<Specialty[]>>(`/institutions/${id}/specialties/`, { params }).then(responseBody),
	details: (id: string, specialtyId: string) =>
		requests.get<Specialty>(`/institutions/${id}/specialties/${specialtyId}`),
	create: (id: string, specialty: Specialty) =>
		requests.post<void>(`/institutions/${id}/specialties/`, specialty),
	edit: (id: string, specialtyId: string, specialty: Specialty) =>
		requests.put<void>(`/institutions/${id}/specialties/${specialtyId}`, specialty),
	delete: (id: string, specialtyId: string) =>
		requests.delete<void>(`/institutions/${id}/specialties/${specialtyId}`)
}

const Disciplines = {
	list: (id: string, specialtyId: string) =>
		requests.get<Discipline[]>(`/institutions/${id}/specialties/${specialtyId}/disciplines`),
	create: (id: string, specialtyId: string, discipline: Discipline) =>
		requests.post<void>(`/institutions/${id}/specialties/${specialtyId}/disciplines`, discipline),
	edit: (id: string, specialtyId: string, disciplineId: string, discipline: Discipline) =>
		requests.put<void>(`/institutions/${id}/specialties/${specialtyId}/disciplines/${disciplineId}`, discipline),
	delete: (id: string, specialtyId: string, disciplineId: string) =>
		requests.delete<void>(`/institutions/${id}/specialties/${specialtyId}/disciplines/${disciplineId}`)
}

const Menus = {
	regionsList: () =>
		requests.get<Region[]>(`/menu/regions`),
	specialtyBasesList: () =>
		requests.get<SpecialtyBase[]>(`/menu/specialtyBases`),
	degreesList: () =>
		requests.get<Degree[]>(`/menu/degrees`),
}

const Profiles = {
	list: (username: string) =>
		requests.get<Profile>(`/profile/${username}`),
	edit: (profile: Partial<Profile>) =>
		requests.put<void>(`/profile/`, profile),
	selectedList: () => requests.get<Institution[]>('/profile/selected')
}

const Photos = {
	listInstitutionPhotos: (id: string) => requests.get<Photo[]>(`/photos/${id}/gallery`),
	addPhoto: (file: Blob) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>('photos', formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	addInstitutionGalleryPhoto: (file: Blob, institutionId: string) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>(`photos/${institutionId}/gallery`, formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	addInstitutionTitlePhoto: (file: Blob, institutionId: string) => {
		let formData = new FormData();
		formData.append('File', file);
		return axios.post<Photo>(`photos/${institutionId}/titleImage`, formData, {
			headers: { 'Content-Type': 'multipart/form-data' }
		})
	},
	delete: (id: string) => requests.delete<void>(`photos/${id}`)
}

const agent = {
	Institutions,
	Specialties,
	Disciplines,
	Menus,
	Profiles,
	Photos
}

export default agent;