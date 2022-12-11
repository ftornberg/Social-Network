import { useEffect, useState } from 'react';
import { useMutation, useQueryClient } from 'react-query';
import { Link } from 'react-router-dom';
import agent from '../actions/agent';
import { User } from '../models/user';

const ShowUsers = () => {
	const queryClient = useQueryClient();
	const [users, setUsers] = useState<User[]>([]);
	useEffect(() => {
		agent.ApplicationUser.list().then((response) => {
			setUsers(response);
		});
	}, []);

	const addPostMutation = useMutation({
		mutationFn: (id: number) => {
			return agent.ApplicationFollower.follow({
				followerUserId: 1,
				followerUserName: '',
				followsUserId: id,
				followsUserName: '',
			});
		},
		onSuccess: () => {
			queryClient.invalidateQueries(['UserFollowsData']);
			queryClient.invalidateQueries(['UserFollowerData']);
		},
	});

	return (
		<div className="container">
			<h1 className="display-2">Hitta vänner</h1>
			<div className="row">
				{users &&
					users.map((user, index: number) => (
						<div key={index} className="col-4 my-3">
							<div className="card rounded shadow-lg" style={{ width: 400 }}>
								<Link to={`/user/${user.id}`}>
									<img
										className="card-img-top mr-3 pe-4 rounded"
										src={`https://i.pravatar.cc/500?u=${user.name}`}
									/>
								</Link>
								<div className="card-body">
									<h5 className="card-title">{user.name}</h5>

									<p className="card-text">
										Ett litet exempel för att visa hur text fyller ut kortens
										titel och innehåll. Här kan användarna skriva en kort
										introduktion.
									</p>
									<button
										onClick={() => addPostMutation.mutate(user.id)}
										type="button"
										className="btn btn-success m-4"
									>
										Follow
									</button>
								</div>
							</div>
						</div>
					))}
			</div>
		</div>
	);
};

export default ShowUsers;
