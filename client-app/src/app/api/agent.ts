import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { history } from "../..";
import { toast } from "react-toastify";
import { store } from "../stores/store";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";
import { University } from "../models/university";

const sleep = (delay: number) => {
	return new Promise((resolve) => {
		setTimeout(resolve, delay)
	})
}

axios.defaults.baseURL = 'http://localhost:5000/api'

axios.interceptors.response.use(async resopnse => {
	await sleep(1000);
	return resopnse
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
			toast.error('/unauthorized');
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

const Universities = {
	list: () => requests.get<University[]>('/universities')
}

const agent = {
	Universities
}

export default agent;