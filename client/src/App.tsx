import './App.css';
import UserWall from './component/UserWall';
import { QueryClient, QueryClientProvider } from 'react-query';
import { createBrowserRouter, Link, RouterProvider } from 'react-router-dom';
import HomePage from './pages/HomePage';
import { ReactQueryDevtools } from 'react-query/devtools';
import DirectMessagePage from './pages/DirectMessagePage';
import FindFriendsPage from './pages/FindFriendsPage';

const queryClient = new QueryClient();

const router = createBrowserRouter([
	{
		path: '/',
		element: <HomePage />,
	},
	{
		path: 'user/:userId',
		element: <UserWall />,
	},
	{
		path: 'conversation/:userId',
		element: <DirectMessagePage />,
	},
	{
		path: 'findfriends',
		element: <FindFriendsPage />,
	},
]);

function App() {
	return (
		<div className="container-fluid justify-content-center">
			<a
				href="/"
				className="d-flex align-items-center link-dark text-decoration-none"
			>
				<h1 className="display-1 center">Social Network</h1>
			</a>
			<QueryClientProvider client={queryClient}>
				<RouterProvider router={router} />
				<ReactQueryDevtools initialIsOpen={true} />
			</QueryClientProvider>
		</div>
	);
}

export default App;
