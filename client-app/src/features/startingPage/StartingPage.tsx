import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { useStore } from '../../app/stores/store';
import BranchOfKnowledgeList from './BranchOfKnowledgeList';

export default observer(function StartingPage() {
	const { stepStore, universityStore } = useStore();
	const { setCurrentStep } = stepStore;
	const { universities, loadUniversities } = universityStore;

	useEffect(() => {
		if (universities.length === 0) {
			loadUniversities();
			setCurrentStep(<BranchOfKnowledgeList key={1} />)
		}
	}, [universities.length, loadUniversities, setCurrentStep])

	if (universityStore.loadingInitial) {
		return <LoadingComponent content='Завантаження фільтрів...' />
	}

	return (
		<Container style={{ marginTop: "4em" }}>
			{stepStore.currentStep}
		</Container>
	)
})