import { Navigate, RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../../app/layout/App";
import HigherEducationFacilityPage from "../higherEducationFacilities/higherEducationFacilityPage/HigherEducationFacilityPage";
import NotFound from "../errors/NotFound";
import ServerError from "../errors/ServerError";

export const routes: RouteObject[] = [
	{
		path: '/',
		element: <App />,
		children: [
			{ path: '/higherEducationFacility/:id', element: <HigherEducationFacilityPage /> },
			{ path: '/not-found', element: <NotFound /> },
			{ path: '/server-error', element: <ServerError /> },
			{ path: '/*', element: <Navigate replace to='/not-found' /> }
		]
	}
];

export const router = createBrowserRouter(routes);