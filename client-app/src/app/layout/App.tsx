import { observer } from 'mobx-react-lite';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import DisciplineList from '../../features/disciplines/DisciplinesList';
import HomePage from '../../features/home/HomePage';

function App() {
	return (
		<>
			<ToastContainer position='bottom-right' hideProgressBar />
			<Routes>
				<Route path='' element={<HomePage />} />
				<Route path='/disciplines' element={<DisciplineList />} />
			</Routes>
		</>
	);
}

export default observer(App);
