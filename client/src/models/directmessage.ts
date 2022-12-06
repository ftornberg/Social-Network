export interface DirectMessage {
	id: number;
	sender: string;
	reciever: string;
	message: string;
	timesent: Date;
}

export interface DirectMessageDto {
	sender: string;
	reciever: string;
	message: string;
	timesent: Date;
}
