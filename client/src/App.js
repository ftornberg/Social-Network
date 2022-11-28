import logo from './logo.svg';
import './App.css';
import ShowUser from './component/ShowUser.tsx';

function App() {
	return (
		<div className="App">
			<header className="App-header">
				<img src={logo} className="App-logo" alt="logo" />
				<p>
					<ShowUser />
				</p>
			</header>
		</div>
	);
}

export default App;
