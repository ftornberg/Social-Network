import axios, { AxiosResponse } from 'axios';
import { CreatePost, Post } from '../models/post';
import { Register, User } from '../models/user';

axios.defaults.baseURL = 'http://localhost:5000/api';
axios.defaults.headers.delete['Content-Type'] = 'application/json';

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
	get: <T>(url: string, params?: URLSearchParams) =>
		axios.get<T>(url, { params }).then(responseBody),
	post: <T>(url: string, body: {}) =>
		axios.post<T>(url, body).then(responseBody),
	put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
	del: <T>(url: string, body: {}) => axios.delete<T>(url).then(responseBody),
};

const ApplicationUser = {
	list: () => requests.get<User[]>('/user/users'),
	getUser: (id: number) => requests.get<User>('/user/' + id),
	registerUser: (user: Register) => requests.post<User>('/user/register', user),
};

const ApplicationPost = {
	getAllPosts: (userId: number) =>
		requests.get<Post[]>('/post/getposts/?postedToUserId=' + userId),
	getPost: (id: number) => requests.get<Post>('/post/' + id),
	createPost: (post: CreatePost) =>
		requests.post<Post>('/post/createpost/', post),
};

const agent = {
	ApplicationUser,
	ApplicationPost,
};

export default agent;
