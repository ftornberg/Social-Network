import './App.css';
import ShowUsers from './component/ShowUsers';
import ShowUser from './component/ShowUser';
import RegisterUser from './component/RegisterUser';

function App() {
	return (
		<div className="App">
			<header className="App-header">
				<div className="Input-fields">
					<RegisterUser />
					<ShowUser />
				</div>
				<div className="Present-user-fields">
					<ShowUsers />
				</div>
			</header>
		</div>
	);
}

export default App;
