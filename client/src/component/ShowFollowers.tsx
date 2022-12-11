import { useQuery } from 'react-query';
import { Link } from 'react-router-dom';
import agent from '../actions/agent';
import Loading from './Loading';

const ShowFollowers = () => {
	const { isLoading, error, data } = useQuery({
		queryKey: ['UserFollowerData'],
		queryFn: () => {
			return agent.ApplicationFollower.listMyFollowers(1).then(
				(response) => response
			);
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
			<Link to={`/findfriends/`} className="link-dark text-decoration-none">
				<div className="row r``ounded">
					<div className="col-sm bg-light text-dark p-4 mb-4 rounded">
						Antingen så har ett fel inträffat, eller så följer du inte någon. Gå
						och gör det nu!
					</div>
				</div>
			</Link>
		);

	return (
		<>
			<li className="p-2">Mina följare:</li>
			{data &&
				data.map((followers, index: number) => (
					<Link
						key={index}
						to={`/user/${followers.followerUserId}`}
						className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
					>
						<li>
							<img
								className="mr-2 pe-4 rounded-circle"
								src={`https://i.pravatar.cc/50?=${followers.followerUserId}`}
								alt="{followers.followerUserName}"
							/>
							{followers.followerUserName}
						</li>
					</Link>
				))}
			<li></li>
		</>
	);
};

export default ShowFollowers;
