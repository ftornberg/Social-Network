export interface DirectMessage {
	id: number;
	senderUserId: number;
	senderUserName: string;
	receiverUserId: number;
	receiverUserName: string;
	message: string;
	timeSent: Date;
}

export interface SendDirectMessage {
	senderUserId: number;
	receiverUserId: number;
	message: string;
}

export interface DirectMessageConversation {
	id: number;
	userId: number;
	userName: string;
}
