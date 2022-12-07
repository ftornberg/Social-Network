import React from 'react';
import SideBar from '../component/SideBar';
import Wall from '../component/Wall';

const HomePage = () => {
	return (
		<div className="container-fluid">
			<div className="row">
				<div className="col-2">
					<SideBar />
				</div>
				<div className="col-6">
					<Wall />
				</div>
			</div>
		</div>
	);
};

export default HomePage;
