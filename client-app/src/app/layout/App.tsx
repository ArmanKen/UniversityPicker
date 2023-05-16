import { observer } from 'mobx-react-lite';
import { Outlet, useLocation } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import { Container } from 'semantic-ui-react';
import ModalContainer from '../common/modals/ModalContainer';
import ScrollToTop from "../common/components/ScrollToTopButton";
import { useStore } from "../stores/store";
import NavBar from './NavBar';
import UniversityDashboard from "../../features/universities/dashboard/UniversityDashboard";

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
					<UniversityDashboard />}
				{!open &&
					<ScrollToTop />}
			</Container>
		</>
	);
}

export default observer(App);