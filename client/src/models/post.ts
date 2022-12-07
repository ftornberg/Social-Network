export interface Post {
	id: number;
	postedMessage: string;
	postedByUserId: number;
	postedToUserId: number;
	postedTime: Date;
}

export interface CreatePost {
	postedMessage: string;
	postedByUserId: number;
	postedToUserId: number;
}
