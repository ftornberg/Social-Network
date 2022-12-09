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
	sender: number;
	receiver: number;
	message: string;
}
