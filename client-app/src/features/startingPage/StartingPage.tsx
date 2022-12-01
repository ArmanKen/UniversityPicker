import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { useStore } from '../../app/stores/store';
import BranchOfKnowledgeList from './BranchOfKnowledgeList';

export default observer(function StartingPage() {
	const { stepStore, branchOfKnowledgeStore, specialtyStore, disciplineStore } = useStore();
	const { allStepsToDefault, setCurrentStep } = stepStore;
	const { branchesOfKnowledge, loadBranchesOfKnowledge } = branchOfKnowledgeStore;
	const { specialties, loadSpecialties } = specialtyStore;
	const { disciplines, loadDisciplines } = disciplineStore;

	useEffect(() => {
		if (branchesOfKnowledge.length <= 1) loadBranchesOfKnowledge();
		if (specialties.length <= 1) loadSpecialties();
		if (disciplines.length <= 1) loadDisciplines();
		allStepsToDefault();
		setCurrentStep(<BranchOfKnowledgeList />)
	}, [branchesOfKnowledge.length, specialties.length, disciplines.length
		, loadBranchesOfKnowledge, loadSpecialties, loadDisciplines, allStepsToDefault, setCurrentStep])

	if (branchOfKnowledgeStore.loadingInitial || specialtyStore.loadingInitial || disciplineStore.loadingInitial) {
		return <LoadingComponent content='Завантаження фільтрів...' />
	}

	return (
		<Container style={{ marginTop: "4em" }}>
			{stepStore.currentStep}
		</Container>
	)
})