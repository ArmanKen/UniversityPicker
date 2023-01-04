import { observer } from 'mobx-react-lite';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import HomePage from '../../features/home/HomePage';
import StartingPageSteps from '../../features/startingPage/StartingPageSteps';
import StartingPage from '../../features/startingPage/StartingPage';
import ModalContainer from '../common/modals/ModalContainer';
import { Container, Divider } from 'semantic-ui-react';
import NotFound from '../../features/errors/NotFound';
import TestErrors from '../../features/errors/TestError';
import ServerError from '../../features/errors/ServerError';
import UniversityDashboard from '../../features/universities/dashboard/UniversityDashboard';
import NavBar from './NavBar';

function App() {
	return (
		<>
			<ToastContainer position='bottom-right' hideProgressBar />
			<ModalContainer />
			<Routes>
				<Route path='' element={<HomePage />} />
				<Route path='/start' element={
					<>
						<StartingPageSteps />
						<StartingPage />
					</>
				} />
				<Route path='/*' element={
					<>
						<NavBar />
						<Container style={{ marginTop: "7em", width: '100%' }}>
							<Routes>
								<Route path='/universities' element={<UniversityDashboard />} />
								<Route path='/errors' element={<TestErrors />} />
								<Route path='/server-error' element={<ServerError />} />
								<Route path='/*' element={<NotFound />} />
							</Routes>
						</Container>
					</>
				} />
			</Routes>
		</>
	);
}

export default observer(App);
