import { observer } from 'mobx-react-lite';
import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import { Container } from 'semantic-ui-react';
import BranchOfKnowledgeList from '../../features/branchesOfKnowledge/BranchOfKnowledgeList';
import DisciplineList from '../../features/disciplines/DisciplinesList';
import HomePage from '../../features/home/HomePage';
import FilteringOptionPickSteps from './FilteringOptionPickSteps';

function App() {
	return (
		<>
			<ToastContainer position='bottom-right' hideProgressBar />
			<Routes>
				<Route path='' element={<HomePage />} />
				<Route path='/*' element={
					<>
						<FilteringOptionPickSteps />
						<Container style={{ marginTop: "4em" }}>
							<Routes>
								<Route path='/branchesOfKnowledge' element={<BranchOfKnowledgeList />} />
								<Route path='/disciplines' element={<DisciplineList />} />
							</Routes>
						</Container>
					</>
				} />
			</Routes>
		</>
	);
}

export default observer(App);
