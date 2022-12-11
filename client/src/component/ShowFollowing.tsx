import { useQuery } from 'react-query';
import { Link } from 'react-router-dom';
import agent from '../actions/agent';
import Loading from './Loading';

const ShowFollowing = () => {
	const { isLoading, error, data } = useQuery({
		queryKey: ['UserFollowsData'],
		queryFn: () => {
			return agent.ApplicationFollower.listWhoImFollowing(1).then(
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
						Antingen så har ett fel inträffat, eller så följer ingen dig. Visa
						vägen genom att följa några!
					</div>
				</div>
			</Link>
		);

	return (
		<>
			<li className="p-2">Jag följer:</li>
			{data &&
				data.map((followers, index: number) => (
					<Link
						key={index}
						to={`/user/${followers.followsUserId}`}
						className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
					>
						<li>
							<img
								className="mr-2 pe-4 rounded-circle"
								src={`https://i.pravatar.cc/50?=${followers.followsUserId}`}
								alt="{followers.followerUserName}"
							/>
							{followers.followsUserName}
						</li>
					</Link>
				))}
			<li></li>
		</>
	);
};

export default ShowFollowing;
