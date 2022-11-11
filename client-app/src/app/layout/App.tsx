import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import DisciplineList from '../../features/disciplines/DisciplinesList';

function App() {
	return (
		<>
			<ToastContainer position='bottom-right' hideProgressBar />
			<Routes>
				<Route path='/disciplines' element={<DisciplineList />} />
			</Routes>
		</>
	);
}

export default App;
