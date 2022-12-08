export interface DirectMessage {
	id: number;
	sender: number;
	receiver: number;
	message: string;
	timeSent: Date;
}

export interface SendDirectMessage {
	sender: number;
	receiver: number;
	message: string;
}
