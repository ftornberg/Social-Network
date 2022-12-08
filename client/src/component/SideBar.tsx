import React from 'react';
import SendMessage from './SendMessage';

const SideBar = () => {
	return (
		<div
			className="d-flex flex-column flex-shrink-0 p-3 bg-light shadow-lg rounded"
			style={{ width: 280 }}
		>
			<a
				href="/"
				className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
			>
				<svg className="bi me-2" width="40" height="32" />
				<span className="fs-4">Skicka DM</span>
			</a>
			<hr />
			<ul className="nav nav-pills flex-column mb-auto">
				<li className="text-start">
					<SendMessage />
				</li>
				<li>
					<a href="#" className="nav-link link-dark">
						Followers
					</a>
				</li>
			</ul>
			<hr />
			<div className="dropdown">
				<ul
					className="dropdown-menu text-small shadow"
					aria-labelledby="dropdownUser2"
				>
					<li>
						<a className="dropdown-item" href="#">
							New project...
						</a>
					</li>
					<li>
						<a className="dropdown-item" href="#">
							Settings
						</a>
					</li>
					<li>
						<a className="dropdown-item" href="#">
							Profile
						</a>
					</li>
					<li>
						<hr className="dropdown-divider" />
					</li>
					<li>
						<a className="dropdown-item" href="#">
							Sign out
						</a>
					</li>
				</ul>
			</div>
		</div>
	);
};

export default SideBar;
