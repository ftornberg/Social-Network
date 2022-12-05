import { ChangeEvent, useState } from 'react';
import agent from '../actions/agent';
import { Register } from '../models/user';

const RegisterUser = () => {
	const [values, setValues] = useState<Register>({
		email: '',
		password: '',
		name: '',
	});
	const { email, password, name } = values;

	const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
		const { name, value } = event.target;
		setValues({ ...values, [name]: value });
	};

	const handleClick = () => {
		let register: Register = {
			name: name,
			email: email,
			password: password,
		};

		agent.ApplicationUser.registerUser(register).then((response) => {
			console.log(response);
			setValues(response);
		});
	};

	return (
		<div>
			<h1>Registrera</h1>
			<form onSubmit={handleClick}>
				<input
					value={name}
					name="name"
					placeholder="Namn"
					onInput={handleInputChange}
				/>
				<br />
				<input
					value={email}
					type="email"
					name="email"
					placeholder="Email"
					onInput={handleInputChange}
				/>
				<br />
				<input
					value={password}
					type="password"
					name="password"
					placeholder="Lösenord"
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
