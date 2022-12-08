export interface Post {
	id: number;
	postedMessage: string;
	postedByUserId: number;
	postedByUserName: string;
	postedToUserId: number;
	postedTime: Date;
}

export interface CreatePost {
	postedMessage: string;
	postedByUserId: number;
	postedByUserName: string;
	postedToUserId: number;
}
