import { observer } from 'mobx-react-lite';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import HomePage from '../../features/home/HomePage';
import StartingPageSteps from '../../features/startingPage/StartingPageSteps';
import StartingPage from '../../features/startingPage/StartingPage';

function App() {
	return (
		<>
			<ToastContainer position='bottom-right' hideProgressBar />
			<Routes>
				<Route path='' element={<HomePage />} />
				<Route path='/start' element={
					<>
						<StartingPageSteps />
						<StartingPage />
					</>
				} />
			</Routes>
		</>
	);
}

export default observer(App);
