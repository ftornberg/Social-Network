import { useMutation, useQueryClient } from 'react-query';
import { ChangeEvent, useState } from 'react';
import { useEffect } from 'react';
import agent from '../actions/agent';
import { SendDirectMessage } from '../models/directmessage';

const SendMessage = () => {
	const queryClient = useQueryClient();
	const [inputValue, setInputValue] = useState(null);
	const [values, setValues] = useState<SendDirectMessage>({
		senderUserId: 1,
		receiverUserId: 0,
		message: '',
	});

	const { senderUserId, receiverUserId, message } = values;

	const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
		const { name, value } = e.target;
		setValues({ ...values, [name]: value });
	};

	const [user, setUser] = useState<any>([]);
	useEffect(() => {
		agent.ApplicationUser.getUser(1).then((response) => {
			setUser(response);
		});
	}, []);

	const addPostMutation = useMutation({
		mutationFn: () => {
			return agent.ApplicationDirectMessage.sendMessage({
				senderUserId: senderUserId,
				receiverUserId: receiverUserId,
				message: message,
			});
		},
		onSuccess: () => {
			queryClient.invalidateQueries(['directMessageData, showMessageData']);
			setInputValue(null);
		},
	});

	return (
		<>
			<div className="input-group mb-3">
				<span className="input-group-text" id="basic-addon1">
					Från:
				</span>
				<input
					type="text"
					className="form-control"
					placeholder={user.name}
					aria-label="Username"
					aria-describedby="basic-addon1"
					disabled
				/>
			</div>
			<div className="input-group mb-3">
				<span className="input-group-text" id="basic-addon1">
					Till:
				</span>
				<input
					type="text"
					className="form-control"
					name="receiverUserId"
					value={receiverUserId}
					placeholder="Mottagare"
					aria-label="Username"
					aria-describedby="basic-addon1"
					onInput={handleInputChange}
				/>
			</div>
			<div className="input-group mb-3">
				<input
					type="text"
					className="form-control"
					name="message"
					value={message}
					placeholder="Meddelande"
					aria-label="message"
					aria-describedby="button-addon2"
					onInput={handleInputChange}
				/>
				<button
					className="btn btn-outline-secondary"
					type="button"
					id="button-addon2"
					onClick={() => addPostMutation.mutate()}
				>
					Skicka
				</button>
			</div>
		</>
	);
};

export default SendMessage;
