import './App.css';
import ShowUsers from './component/ShowUsers';
import ShowUser from './component/ShowUser';
import RegisterUser from './component/RegisterUser';

function App() {
	return (
		<div className="App">
			<header className="App-header">
				<RegisterUser />
				<ShowUsers />
				<ShowUser />
			</header>
		</div>
	);
}

export default App;
