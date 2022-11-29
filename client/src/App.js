import logo from './logo.svg';
import './App.css';
import ShowUsers from './component/ShowUsers';
import ShowUser from './component/ShowUser';


function App() {
	return (
		<div className="App">
			<header className="App-header">
				<img src={logo} className="App-logo" alt="logo" />
				Show Users
				<ShowUsers />
				Show User
				<ShowUser />
			</header>
		</div>
	);
}

export default App;
