import { useQuery } from '@tanstack/react-query';
import userEvent from '@testing-library/user-event';
import { useEffect, useState } from 'react';
import Moment from 'react-moment';
import agent from '../actions/agent';
import Loading from './Loading';

const ShowMessages = () => {
	const { isLoading, error, data } = useQuery({
		queryKey: ['directMessageData'],
		queryFn: () =>
			agent.ApplicationDirectMessage.list(1, 3).then((response) => response),
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
				<h2>Conversation between 1 and 3:</h2>
				<button type="button" className="btn btn-primary m-4">
					Meddelanden: <span className="badge badge-light">{data?.length}</span>
				</button>
				{data &&
					data.map((dm) => (
						<li
							className="media bg-white text-dark p-4 mb-4 border rounded shadow-lg"
							key={dm.id}
						>
							<img
								className="mr-3 pe-4 rounded-circle"
								src={`https://i.pravatar.cc/75?=${dm.sender}`}
								alt="{messages.sender}"
							/>
							<div className="media-body">
								<p className="mt-0 mb-1 lead">{dm.message}</p>
								<Moment format="DD/MM/YY HH:mm">{dm.timeSent}</Moment>
								<>{console.log(data)}</>
							</div>
						</li>
					))}
			</ul>
		</div>
	);
};

export default ShowMessages;
