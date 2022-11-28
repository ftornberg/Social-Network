import axios from 'axios';
import React, { useEffect, useState } from 'react';

const ShowUser = () => {
	const [user, setUser] = useState();

	useEffect(() => {
		axios.get('http://localhost:5000/api/user').then((response) => {
			console.log(response);
			setUser(response.data);
		});
	}, []);

	return <>hej</>;
};

export default ShowUser;
