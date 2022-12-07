import axios, { AxiosResponse } from 'axios';
import { CreatePost, Post } from '../models/post';
import { Register, User } from '../models/user';
import { DirectMessageDto, DirectMessage } from '../models/directmessage';

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
const ApplicationDirectMessage = {
	list: (sender: number, receiver: number) =>
		requests.get<DirectMessage[]>(
			'/DirectMessage/GetMessages?sender=' + sender + '&receiver=' + receiver
		),
	sendMessage: (directMessageDto: DirectMessageDto) =>
		requests.post<DirectMessage>(
			'/DirectMessage/SendMessage',
			directMessageDto
		),
};

const ApplicationUser = {
	list: () => requests.get<User[]>('/user/Users'),
	getUser: (id: number) => requests.get<User>('/user/' + id),
	registerUser: (user: Register) => requests.post<User>('/user/Register', user),
};

const ApplicationPost = {
	getAllPosts: (userId: number) =>
		requests.get<Post[]>('/post/GetPostsToSpecificUser/?postedToUserId=' + userId),
	getPost: (id: number) => requests.get<Post>('/post/' + id), //Ta bort denna rad i frontend eller gör om till GetAllPost
	createPost: (post: CreatePost) =>
		requests.post<Post>('/post/CreatePost/', post),
};

const agent = {
	ApplicationUser,
	ApplicationPost,
	ApplicationDirectMessage,
};

export default agent;
