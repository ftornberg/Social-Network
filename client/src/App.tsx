import './App.css';
import Wall from './component/Wall';
import UserWall from './component/UserWall';
import { QueryClient, QueryClientProvider } from 'react-query';
import { createBrowserRouter, Link, RouterProvider } from 'react-router-dom';
import HomePage from './pages/HomePage';
import { ReactQueryDevtools } from 'react-query/devtools';

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
			<a
				href="/"
				className="d-flex align-items-center mb-3 mb-md-0 me-md-auto link-dark text-decoration-none"
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
