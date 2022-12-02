import axios, { AxiosResponse } from 'axios';
import { User } from '../models/user';

axios.defaults.baseURL = 'http://localhost:5000/api';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
	get: <T>(url: string, params?: URLSearchParams) =>
		axios.get<T>(url, { params }).then(responseBody),
	post: <T>(url: string, body: {}) =>
		axios.post<T>(url, body).then(responseBody),
	put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
	del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const ApplicationUser = {
	list: () => requests.get<User[]>('/user/users'),
	getUser: (id: number) => requests.get<User>('/user/' + id),
	registerUser: (user: User) => requests.post<User>('/user/register', user),
};

const agent = {
	ApplicationUser,
};

export default agent;
