import { useQuery } from 'react-query';
import Moment from 'react-moment';
import agent from '../actions/agent';
import Loading from './Loading';
import { defaultMethod } from 'react-router-dom/dist/dom';
import userEvent from '@testing-library/user-event';
import { useEffect } from 'react';

const ShowMessages = () => {
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
		<div className="container">
			<div className="clearfix"></div>
			<ul className="list-unstyled p-3 mb-2">
				<h2>Meddelanden</h2>
				{data &&
					data.map((message, index: number) => (
						<div className="row my-3 shadow-lg">
							<div className="card px-0" key={index}>
								<div className="card-header">
									<h5 className="card-title">{message.userName}</h5>
								</div>
							</div>
						</div>
					))}
			</ul>
		</div>
	);
};

export default ShowMessages;
