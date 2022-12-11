import { useParams } from 'react-router-dom';
import Conversations from '../component/Conversations';
import ShowMessages from '../component/ShowMessages';
import SideBar from '../component/SideBar';

const DirectMessagePage = () => {
	const { id } = useParams<{ id: string }>();
	console.log('Det här är UserID i DM-Page:', id);
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
