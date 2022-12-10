import Moment from 'react-moment';
import { useQuery } from 'react-query';
import agent from '../actions/agent';
import Loading from './Loading';

const Conversations = () => {
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
		<div className="container-fluid">
			<div className="clearfix"></div>
			<ul className="list-unstyled p-3 mb-2">
				<h2>Konversationer</h2>
				{data &&
					data.map((conversations) => (
						<div className="row">
							<li
								className="media bg-white text-dark p-4 mb-4 border rounded shadow-lg"
								key={conversations.id}
							>
								<img
									className="mr-3 pe-4 rounded-circle"
									src={`https://i.pravatar.cc/25?=${conversations.userName}`}
									alt="{dm.senderName}"
								/>
								<div className="media-body">
									<>{conversations.userName}</>
								</div>
							</li>
						</div>
					))}
			</ul>
		</div>
	);
};

export default Conversations;
