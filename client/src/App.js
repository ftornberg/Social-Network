import logo from './logo.svg';
import './App.css';
import ShowUsers from './component/ShowUsers';

function App() {
	return (
		<div className="App">
			<header className="App-header">
				<img src={logo} className="App-logo" alt="logo" />
				Show Users
				<ShowUsers />
			</header>
		</div>
	);
}

export default App;
