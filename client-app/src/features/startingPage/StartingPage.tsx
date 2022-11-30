import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { useStore } from '../../app/stores/store';
import BranchOfKnowledgeList from './BranchOfKnowledgeList';
import DisciplinesList from './DisciplinesList';
import SpecialtyPick from './SpecialtyPick';

export default observer(function StartingPage() {
	const { stepStore, branchOfKnowledgeStore, specialtyStore, disciplineStore } = useStore();
	const { branchOfKnowledgeStep, specilatyStep, disciplineStep } = stepStore;
	const { branchesOfKnowledge, loadBranchesOfKnowledge } = branchOfKnowledgeStore;


	useEffect(() => {
		if (branchesOfKnowledge.length <= 1) loadBranchesOfKnowledge();
	}, [branchesOfKnowledge.length, loadBranchesOfKnowledge])

	if (branchOfKnowledgeStore.loadingInitial) return <LoadingComponent content='Loading branches of knowledge...' />

	return (
		<Container style={{ marginTop: "4em" }}>
			{branchOfKnowledgeStep.active ? (
				<BranchOfKnowledgeList />
			) : specilatyStep.active ? (
				<SpecialtyPick />
			) : (
				<DisciplinesList />
			)}
		</Container>
	)
})