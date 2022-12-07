import './App.css';
import Wall from './component/Wall';
import UserWall from './component/UserWall';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';

const queryClient = new QueryClient();

const router = createBrowserRouter([
	{
		path: '/',
		element: <Wall />,
	},
	{
		path: 'user/:userId',
		element: <UserWall />,
	},
]);

function App() {
	return (
		<div className="container">
			<h1 className="display-1 center">Social Network</h1>
			<QueryClientProvider client={queryClient}>
				<RouterProvider router={router} />
			</QueryClientProvider>
		</div>
	);
}

export default App;
