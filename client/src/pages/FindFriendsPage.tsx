import ShowUsers from '../component/ShowUsers';
import SideBar from '../component/SideBar';

const FindFriendsPage = () => {
	return (
		<div className="container-fluid">
			<div className="row">
				<div className="col-2">
					<SideBar />
				</div>
				<div className="col-6 rounded shadow-lg">
					<ShowUsers />
				</div>
			</div>
		</div>
	);
};

export default FindFriendsPage;
