import { useState } from 'react';
import { useQuery } from 'react-query';
import { Link } from 'react-router-dom';
import agent from '../actions/agent';
import Loading from './Loading';
import ShowMessages from './ShowMessages';

const Conversations = () => {
	const [receiver, setReceiver] = useState<number>();
	const getReceiver = (id: number) => {
		setReceiver(id);
	};
	const { isLoading, error, data } = useQuery({
		queryKey: ['directMessageData'],
		queryFn: () =>
			agent.ApplicationDirectMessage.listAllConversationsWithUser(1).then(
				(response) => response
			),
	});

	if (isLoading)
		return (
			<>
				<Loading />
			</>
		);

	if (error)
		return (
			<div className="row rounded">
				<div className="col-sm bg-light text-dark p-4 mb-4 rounded">
					An error has occurred. Please try again later.
				</div>
			</div>
		);

	return (
		<div className="container d-flex">
			<div className="row">
				<div className="col">
					<div className="text-dark p-4 m-4 rounded">
						<h2 className="display-5 ps-4 pt-4">Konversationer</h2>
						<ul className="list-group">
							{data &&
								data.map((conversations, index: number) => (
									<li
										key={index}
										className="list-group-item d-flex justify-content-start align-items-center rounded"
									>
										<Link
											to={`/conversation/${conversations.userId}`}
											className="link-dark text-decoration-none"
											onClick={() => {
												getReceiver(conversations.userId);
											}}
										>
											<img
												className="mr-3 pe-4 rounded-circle"
												src={`https://i.pravatar.cc/40?u=${conversations.userName}`}
												alt="{dm.senderName}"
											/>
											{conversations.userName}
										</Link>
									</li>
								))}
						</ul>
					</div>
				</div>
				<div className="col">
					<ShowMessages chatId={receiver!} />
				</div>
			</div>
		</div>
	);
};

export default Conversations;
