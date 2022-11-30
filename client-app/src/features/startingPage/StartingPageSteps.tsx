import { observer } from 'mobx-react-lite';
import React from 'react';
import { Step } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

export default observer(function StartingPageSteps() {
	const { branchOfKnowledgeStore, disciplineStore } = useStore();
	const {  } = branchOfKnowledgeStore;
	const {  } = disciplineStore;
	return (
		<Step.Group ordered attached='top' fluid>
			<Step completed active>
				<Step.Content>
					<Step.Title>Вибір області знань</Step.Title>
				</Step.Content>
			</Step>

			<Step completed active>
				<Step.Content>
					<Step.Title>Вибір дисциплін</Step.Title>
				</Step.Content>
			</Step>

			<Step>
				<Step.Content>
					<Step.Title>Вибір спеціалізації</Step.Title>
				</Step.Content>
			</Step>
		</Step.Group>
	);
})