import React from 'react';
import Conversations from '../component/Conversations';
import SendMessage from '../component/SendMessage';
import ShowMessages from '../component/ShowMessages';
import SideBar from '../component/SideBar';

const DirectMessagePage = () => {
	return (
		<div className="container-fluid">
			<div className="row align-items-start">
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
