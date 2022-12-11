import { useEffect, useState } from 'react';
import agent from '../actions/agent';

const ShowUser = () => {
	const [user, setUser] = useState<any>([]);

	useEffect(() => {
		const id = Math.floor(Math.random() * 10) + 1;
		agent.ApplicationUser.getUser(id).then((response) => {
			setUser(response);
		});
	}, []);

	return (
		<div>
			<h1>Spotlight</h1>
			<div>
				<h3>{user.name}</h3>
				<p>{user.email}</p>
			</div>
		</div>
	);
};

export default ShowUser;
