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
				<div className="col-6">
					<ShowMessages />
				</div>
				<div className="col-2">
					<Conversations />
				</div>
			</div>
		</div>
	);
};

export default DirectMessagePage;
