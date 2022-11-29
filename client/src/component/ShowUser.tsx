import axios from 'axios';
import React, { useEffect, useState } from 'react';

const ShowUser = () => {
	const [user, setUser] = useState<any>([]);
	var id = 2;
	useEffect(() => {
		axios.get('http://localhost:5000/api/user/' + id).then((response) => {
			console.log(response);
			setUser(response.data);
		});
	}, []);

	return (
		<div>
			<h1>User</h1>
			<ul>
				<li>{user.name}</li>
				<li>{user.email}</li>
			</ul>
		</div>
	);
};

export default ShowUser;
