import Conversations from '../component/Conversations';
import SideBar from '../component/SideBar';

const DirectMessagePage = () => {
	return (
		<div className="container-fluid">
			<div className="row">
				<div className="col-2">
					<SideBar />
				</div>
				<div className="col-8 rounded shadow-lg">
					<Conversations />
				</div>
			</div>
		</div>
	);
};

export default DirectMessagePage;
