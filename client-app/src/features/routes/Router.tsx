import { Navigate, RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../../app/layout/App";
import HigherEducationFacilityPage from "../higherEducationFacilities/higherEducationFacilityPage/HigherEducationFacilityPage";
import NotFound from "../errors/NotFound";
import ServerError from "../errors/ServerError";
import ProfilePage from "../profile/ProfilePage";
import HigherEducationFacilitySettings from "../higherEducationFacilities/higherEducationFacilitySettings/HigherEducationFacilitySettings";
import FacultyPage from "../faculties/facultyPage/FacultyPage";
import SpecialtyPage from "../specialties/specialtyPage/SpecialtyPage";

export const routes: RouteObject[] = [
	{
		path: '/',
		element: <App />,
		children: [
			{ path: '/higherEducationFacility/:id', element: <HigherEducationFacilityPage /> },
			{ path: '/faculty/:id', element: <FacultyPage /> },
			{ path: '/specialty/:id', element: <SpecialtyPage /> },
			{ path: '/settings/higherEducationFacility/:id', element: <HigherEducationFacilitySettings /> },
			{ path: '/profile/:id', element: <ProfilePage /> },
			{ path: '/not-found', element: <NotFound /> },
			{ path: '/server-error', element: <ServerError /> },
			{ path: '/*', element: <Navigate replace to='/not-found' /> }
		]
	}
];

export const router = createBrowserRouter(routes);