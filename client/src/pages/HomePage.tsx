import Conversations from '../component/Conversations';
import SideBar from '../component/SideBar';
import Wall from '../component/Wall';

const HomePage = () => {
	return (
		<div className="container-fluid">
			<div className="row">
				<div className="col-2">
					<SideBar />
				</div>
				<div className="col-5 rounded shadow-lg">
					<Wall />
				</div>
				<div className="col-2 rounded">
					<Conversations />
				</div>
			</div>
		</div>
	);
};

export default HomePage;
