import axios, { AxiosResponse } from 'axios';
import { CreatePost, Post } from '../models/post';
import { Register, User } from '../models/user';
import { FollowUser } from '../models/followers';
import { DirectMessage, SendDirectMessage } from '../models/directmessage';

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
	list: (userOne: number, userTwo: number) =>
		requests.get<DirectMessage[]>(
			'/DirectMessage/GetMessages/' + userOne + '/' + userTwo
		),

	sendMessage: (sendDirectMessage: SendDirectMessage) =>
		requests.post<DirectMessage>(
			'/DirectMessage/SendMessage',
			sendDirectMessage
		),
};

const ApplicationFollower = {
	listWhoImFollowing: (user: number) =>
		requests.get<FollowUser[]>('/Follower/GetWhoUserFollows/' + user),

	listMyFollowers: (user: number) =>
		requests.get<FollowUser[]>('/Follower/GetSpecificUserFollowers/' + user),

	follow: (data: FollowUser) =>
		requests.post<FollowUser[]>('/Follower/FollowUser', data),
};

const ApplicationUser = {
	list: () => requests.get<User[]>('/user/Users'),

	getUser: (id: number) => requests.get<User>('/user/' + id),

	registerUser: (user: Register) => requests.post<User>('/user/Register', user),
};

const ApplicationPost = {
	getAllPostsFromUsersFollowed: (userId: number) =>
		requests.get<Post[]>('post/GetAllPosts/' + userId),

	getAllPostsToUser: (userId: number) =>
		requests.get<Post[]>('/post/GetPostsToSpecificUser/' + userId),

	createPost: (post: CreatePost) =>
		requests.post<Post>('/post/CreatePost/', post),
};

const agent = {
	ApplicationUser,
	ApplicationPost,
	ApplicationDirectMessage,
	ApplicationFollower,
};

export default agent;
