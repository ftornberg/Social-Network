import Moment from 'react-moment';
import { useQuery } from 'react-query';
import { Link } from 'react-router-dom';
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
			<div className="list-unstyled p-3 mb-2">
				<h2>Conversations</h2>
				{data &&
					data.map((conversations) => (
						<Link to={`/conversation/${conversations.userId}`}>
							<div className="container media bg-white text-dark p-4 mb-4 border rounded shadow-lg">
								<div className="row">
									<div className="col" key={conversations.id}>
										<img
											className="mr-3 pe-4 rounded-circle"
											src={`https://i.pravatar.cc/40?=${conversations.userName}`}
											alt="{dm.senderName}"
										/>
										<div className="col">
											<p>{conversations.userName}</p>
										</div>
									</div>
								</div>
							</div>
						</Link>
					))}
			</div>
		</div>
	);
};

export default Conversations;
