import { ChangeEvent, useState } from 'react';
import { useEffect } from 'react';
import agent from '../actions/agent';
import { Register, User } from '../models/user';
import ShowUsers from './ShowUsers';

const RegisterUser = () => {
	const [values, setValues] = useState<Register>({
		id: 0,
		email: '',
		password: '',
		name: '',
	});
	const { email, password, name } = values;

	const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
		const { name, value } = e.target;
		setValues({ ...values, [name]: value });
	};

	const handleClick = () => {
		let register: Register = {
			id: 0,
			name: name,
			email: email,
			password: password,
		};

		agent.ApplicationUser.registerUser(register).then((response) => {
			console.log(response);
			setValues(response);
		});
	};

	useEffect(() => {
		<ShowUsers />;
	}, []);

	return (
		<div>
			<h1>Register</h1>
			<form onSubmit={handleClick}>
				<input
					value={name}
					name="name"
					placeholder="Name"
					onInput={handleInputChange}
				/>
				<br />
				<input
					value={email}
					type="text"
					name="email"
					placeholder="Email"
					onInput={handleInputChange}
				/>
				<br />
				<input
					value={password}
					type="password"
					name="password"
					placeholder="Password"
					onInput={handleInputChange}
				/>
				<br />
				<button type="submit" value="Submit">
					Register
				</button>
			</form>
		</div>
	);
};

export default RegisterUser;
