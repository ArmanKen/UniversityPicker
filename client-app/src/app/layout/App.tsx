import { observer } from 'mobx-react-lite';
import { Outlet, useLocation } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import { Container } from 'semantic-ui-react';
import ModalContainer from '../common/modals/ModalContainer';
import ScrollToTop from "../common/components/ScrollToTopButton";
import { useStore } from "../stores/store";
import NavBar from './NavBar';
import HigherEducationFacilityDashboard from "../../features/higherEducationFacilities/dashboard/HigherEducationFacilityDashboard";

function App() {
	const { modalStore: { open } } = useStore()
	const location = useLocation();

	return (
		<>
			<ToastContainer position='bottom-right' hideProgressBar />
			<ModalContainer />
			<NavBar />
			<Container fluid style={{ width: '98%', marginTop: 60 }}>
				<Outlet />
				{location.pathname === '/' &&
					<HigherEducationFacilityDashboard />}
				{!open &&
					<ScrollToTop />}
			</Container>
		</>
	);
}

export default observer(App);