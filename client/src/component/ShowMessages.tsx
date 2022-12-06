import { useEffect, useState } from 'react';
import agent from '../actions/agent';
import { DirectMessage } from '../models/directmessage';

const ShowMessages = () => {
	const [messages, setMessages] = useState<DirectMessage[]>([]);

	useEffect(() => {
		agent.ApplicationDirectMessage.list(1, 2).then((response) => {
			console.log('ShowMessages:');
			console.log(response);
			setMessages(response);
		});
	}, []);

	return (
		<div className="Present-users-list">
			<h2>Conversaton between user 1 and 2:</h2>
			{messages &&
				messages.map((messages) => (
					<div key={messages.id}>
						<h3>From: {messages.sender}</h3>
						<p>
							{messages.message}
						</p>
					</div>
				))}
		</div>
	);
};

export default ShowMessages;
