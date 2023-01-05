import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import LoadingComponent from '../../app/layout/LoadingComponent';
import { useStore } from '../../app/stores/store';
import StartingPageBranchOfKnowledgePick from './StartingPageBranchOfKnowledgePick';

export default observer(function StartingPage() {
	const { stepStore, universityStore } = useStore();
	const { setCurrentStep } = stepStore;
	const { universities, loadUniversities } = universityStore;

	useEffect(() => {
		setCurrentStep(<StartingPageBranchOfKnowledgePick key={1} />);
	}, [setCurrentStep])

	useEffect(() => {
		if (universities.length === 0) {
			loadUniversities();
		}
	}, [universities.length, loadUniversities])

	if (universityStore.loadingInitial) {
		return <LoadingComponent content='Завантаження фільтрів...' />
	}

	return (
		<Container style={{ marginTop: "4em" }}>
			{stepStore.currentStep}
		</Container>
	)
})