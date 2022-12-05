import './App.css';
import ShowUsers from './component/ShowUsers';
import ShowUser from './component/ShowUser';
import RegisterUser from './component/RegisterUser';
import DeleteUser from './component/DeleteUser';

function App() {
	return (
		<div className="App">
			<header className="App-header">
				<div className="Input-fields">
					{/* <RegisterUser /> */}
					<DeleteUser />
				</div>
				{/* <div className="Present-user-fields">
					<ShowUsers />
					<ShowUser />
				</div> */}
			</header>
		</div>
	);
}

export default App;
