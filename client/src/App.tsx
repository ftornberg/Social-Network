import './App.css';
import ShowUsers from './component/ShowUsers';
import ShowUser from './component/ShowUser';
import RegisterUser from './component/RegisterUser';
import ShowMessages from './component/ShowMessages';
import SendMessage from './component/SendMessage';


function App() {
	return (
		<div className="App">
			<header className="App-header">
				<div className="Input-fields">
					<RegisterUser />
				</div>
				<div className="Present-user-fields">
					<ShowUsers />
					{/* <ShowUser /> */}
				</div>
				<div>
					<SendMessage />
					<ShowMessages />
				</div>
			</header>
		</div>
	);
}

export default App;
