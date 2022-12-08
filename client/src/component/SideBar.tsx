import { useQuery } from '@tanstack/react-query';
import React from 'react';
import { Link, useParams } from 'react-router-dom';
import agent from '../actions/agent';
import Loading from './Loading';
import SendMessage from './SendMessage';

const SideBar = () => {
	const { isLoading, error, data } = useQuery({
		queryKey: ['UserFollowsData'],
		queryFn: () => {
			return agent.ApplicationFollower.list(1).then((response) => response);
		},
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
		<div
			className="d-flex flex-column flex-shrink-0 p-3 bg-light shadow-lg rounded"
			style={{ width: 280 }}
		>
			<a
				href="/"
				className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
			>
				<svg className="bi me-2" width="40" height="32" />
				<span className="fs-4">Min feed</span>
			</a>
			<hr />
			<ul className="nav nav-pills flex-column mb-auto">
				<li className="text-start">Skicka DM</li>
				<li className="text-start">
					<SendMessage />
				</li>
				<li>
					<a href="#" className="nav-link link-dark">
						Jag följer:
					</a>
				</li>
				{data &&
					data.map((followers) => (
						<li>
							<a href="#" className="nav-link link-dark">
								{followers.followerUserId}
							</a>
						</li>
					))}
				<li></li>
				<hr />
				<li>
					<a href="#" className="nav-link link-dark">
						Dessa följer dig:
					</a>
				</li>
				{data &&
					data.map((followers) => (
						<li>
							<Link
								to={`/user/${followers.followerUserId}`}
								className="nav-link link-dark"
							>
								{followers.followerUserId}
							</Link>
						</li>
					))}
				<li></li>
			</ul>
			<hr />
		</div>
	);
};

export default SideBar;
