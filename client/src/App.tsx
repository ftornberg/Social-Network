import './App.css';
import Wall from './component/Wall';
import UserWall from './component/UserWall';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import HomePage from './pages/HomePage';

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
]);

function App() {
	return (
		<div className="container-fluid">
			<h1 className="display-1 center">Social Network</h1>
			<QueryClientProvider client={queryClient}>
				<RouterProvider router={router} />
			</QueryClientProvider>
		</div>
	);
}

export default App;
