import { useQuery } from '@tanstack/react-query';
import { Link } from 'react-router-dom';
import agent from '../actions/agent';

const Wall = () => {
	let userId: number = 1;
	const { isLoading, error, data } = useQuery({
		queryKey: ['wallData'],
		queryFn: () => agent.ApplicationUser.list().then((response) => response),
	});

	if (isLoading)
		return (
			<div className="row rounded">
				<div className="col-sm bg-light text-dark p-4 mb-4 rounded">
					Loading...
				</div>
			</div>
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
			<div className="container">
				<div className="col-sm rounded">
					<div className="clearfix"></div>
					<ul className="list-unstyled p-3 mb-2">
						{data &&
							data.map((user) => (
								<li
									className="media bg-white text-dark p-4 mb-4 border rounded shadow-lg"
									key={user.id}
								>
									<Link to={`/user/${user.id}`}>
										<img
											className="mr-3 rounded-circle"
											src={`https://i.pravatar.cc/75?=${user.name}`}
											alt="{user.name}"
										/>
									</Link>
									<div className="media-body">
										<p className="mt-0 mb-1 lead">{user.name}</p>
										<samp>{user.email}</samp>
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
