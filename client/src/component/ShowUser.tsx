import { useEffect, useState } from 'react';
import agent from '../actions/agent';

const ShowUser = () => {
	const [user, setUser] = useState<any>([]);
	useEffect(() => {
		var id = 2;
		agent.ApplicationUser.getUser(id).then((response) => {
			console.log(response);
			setUser(response);
		});
	}, []);

	return (
		<div>
			<h1>User {user.id}</h1>
			<div>
				<h3>{user.name}</h3>
				<p>{user.email}</p>
			</div>
		</div>
	);
};

export default ShowUser;
