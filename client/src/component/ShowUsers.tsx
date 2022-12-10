import { useEffect, useState } from 'react';
import { useMutation, useQueryClient } from 'react-query';
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
			queryClient.invalidateQueries(['UserFollowsData, UserFollowerData']);
		},
	});

	return (
		<div className="container">
			<h1>Users</h1>
			<div className="row">
				{users &&
					users.map((user, index: number) => (
						<div key={index} className="col-4 my-3">
							<div className="card" style={{ width: 400 }}>
								<img
									className="card-img-top mr-3 pe-4"
									src={`https://i.pravatar.cc/80?=${user.name}`}
								/>
								<div className="card-body">
									<h5 className="card-title">{user.name}</h5>
									<p className="card-text">
										Some quick example text to build on the card title and make
										up the bulk of the card's content.
										<></>
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
