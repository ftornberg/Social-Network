import SendMessage from './SendMessage';
import ShowFollowers from './ShowFollowers';
import ShowFollowing from './ShowFollowing';

const SideBar = () => {
	return (
		<div
			className="d-flex flex-column flex-shrink-0 p-3 pt-6 bg-light shadow-lg rounded border"
			style={{ width: 280 }}
		>
			<a
				href="/"
				className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
			>
				<svg className="bi me-2" width="40" height="32" />
				<span className="fs-4">Hem</span>
			</a>
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
