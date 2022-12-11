import Conversations from '../component/Conversations';
import ShowMessages from '../component/ShowMessages';
import SideBar from '../component/SideBar';

const DirectMessagePage = () => {
	return (
		<div className="container-fluid">
			<div className="row">
				<div className="col-2">
					<SideBar />
				</div>
				<div className="col-5 rounded shadow-lg">
					<ShowMessages />
				</div>
				<div className="col-2 rounded">
					<Conversations />
				</div>
			</div>
		</div>
	);
};

export default DirectMessagePage;
