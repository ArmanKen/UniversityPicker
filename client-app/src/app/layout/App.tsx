import { observer } from 'mobx-react-lite';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import ModalContainer from '../common/modals/ModalContainer';
import { Container, Grid } from 'semantic-ui-react';
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
				<Route path='/*' element={
					<Grid>
						<Grid.Row>
							<NavBar />
						</Grid.Row>
						<Container style={{ marginTop: 75, width: '97%' }}>
							<Routes>
								<Route path='/' element={<UniversityDashboard />} />
								<Route path='/errors' element={<TestErrors />} />
								<Route path='/server-error' element={<ServerError />} />
								<Route path='/*' element={<NotFound />} />
							</Routes>
						</Container>
					</Grid>
				} />
			</Routes>
		</>
	);
}

export default observer(App);
