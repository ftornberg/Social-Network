export interface DirectMessage {
	id: number;
	sender: string;
	receiver: string;
	message: string;
	timesent: Date;
}

export interface DirectMessageDto {
	sender: string;
	receiver: string;
	message: string;
	timesent: Date;
}
