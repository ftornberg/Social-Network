import { Link } from 'react-router-dom';
import SendMessage from './SendMessage';
import ShowFollowers from './ShowFollowers';
import ShowFollowing from './ShowFollowing';

const SideBar = () => {
	return (
		<div
			className="d-flex flex-column flex-shrink-0 p-3 pt-6 bg-light shadow-lg rounded border"
			style={{ width: 280 }}
		>
			<ul className="list-group">
				<li className="list-group-item">
					<Link
						to="/"
						className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
					>
						<span className="fs-4">Hem</span>
					</Link>
				</li>
				<li className="list-group-item">
					<Link
						to="/conversation/$`{userId}`"
						className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
					>
						Konversationer
					</Link>
				</li>
				<li className="list-group-item">
					<a
						href="/conversation/$`{userId}`"
						className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
					>
						Hitta vänner
					</a>
				</li>
			</ul>
			<hr />
			<ul className="nav nav-pills flex-column mb-auto">
				<li className="text-start">Skicka DM</li>
				<li className="text-start">
					<SendMessage />
				</li>
				<li>
					<ShowFollowers />
				</li>
				<li>
					<ShowFollowing />
				</li>
				<hr />
			</ul>
		</div>
	);
};

export default SideBar;
