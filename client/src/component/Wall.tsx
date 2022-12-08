import { useQuery } from '@tanstack/react-query';
import Moment from 'react-moment';
import { Link } from 'react-router-dom';
import agent from '../actions/agent';
import Loading from './Loading';

const Wall = () => {
	const { isLoading, error, data } = useQuery({
		queryKey: ['wallData'],
		queryFn: () =>
			agent.ApplicationPost.getAllPostsFromUsersFollowed(1).then(
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
		<>
			<div className="container-fluid">
				<div className="col-sm rounded">
					<div className="clearfix"></div>
					<ul className="list-unstyled p-3 mb-2">
						{data &&
							data.map((post) => (
								<li
									className="media bg-white text-dark p-4 mb-4 border rounded shadow-lg"
									key={post.id}
								>
									<Link to={`/user/${post.postedToUserId}`}>
										<img
											className="mr-3 pe-4 rounded-circle"
											src={`https://i.pravatar.cc/75?=${post.postedByUserId}`}
											alt={post.postedMessage}
										/>
										<div className="fs-4">{post.postedByUserName}</div>
									</Link>
									<div className="media-body">
										<p className="mt-0 mb-1 lead">{post.postedMessage}</p>
										<samp>
											<Moment format="DD/MM/YY HH:mm">{post.postedTime}</Moment>
										</samp>
									</div>
								</li>
							))}
					</ul>
				</div>
			</div>
		</>
	);
};

export default Wall;
