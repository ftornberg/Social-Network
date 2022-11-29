import { useEffect, useState } from 'react';
import agent from '../actions/agent';
import { User } from '../models/user';

const ShowUsers = () => {
	const [users, setUsers] = useState<User[]>([]);

	useEffect(() => {
		agent.ApplicationUser.list().then((response) => {
			console.log('Showusers:');
			console.log(response);
			setUsers(response);
		});
	}, []);

	return (
		<div>
			<h1>Users</h1>
			{users &&
				users.map((user) => (
					<div key={user.id}>
						<h3>{user.name}</h3>
						<p>{user.email}</p>
					</div>
				))}
		</div>
	);
};

export default ShowUsers;
