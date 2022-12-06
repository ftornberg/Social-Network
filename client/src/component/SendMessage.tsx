import { ChangeEvent, useState } from 'react';
import { useEffect } from 'react';
import agent from '../actions/agent';
import { DirectMessageDto } from '../models/directmessage';

const SendMessage = () => {
	const [values, setValues] = useState<DirectMessageDto>({
		sender: '',
		receiver: '',
		message: '',
		timesent: new Date(),
	});
	const { sender, receiver, message } = values;

	const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
		const { name, value } = e.target;
		setValues({ ...values, [name]: value });
	};

	const handleClick = () => {
		let dto: DirectMessageDto = {
			sender: sender,
			receiver: receiver,
			message: message,
			timesent: new Date()
		};

		agent.ApplicationDirectMessage.sendMessage(dto).then((response) => {
			console.log(response);
			setValues(response);
		});
	};

	useEffect(() => {

	}, []);

	return (
		<div>
			<h1>Send message</h1>
			<form onSubmit={handleClick}>
				<input
					value={sender}
					name="sender"
					placeholder="Send from:"
					onInput={handleInputChange}
				/>
				<br />
				<input
					value={receiver}
					name="receiver"
					placeholder="Send to"
					onInput={handleInputChange}
				/>
				<br />
				<input
					value={message}
					name="message"
					placeholder="Message"
					onInput={handleInputChange}
				/>
				<br />
				<button type="submit" value="Submit">
					Send
				</button>
			</form>
		</div>
	);
};

export default SendMessage;
