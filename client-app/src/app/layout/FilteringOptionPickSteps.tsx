import { observer } from 'mobx-react-lite';
import React from 'react';
import { Step } from 'semantic-ui-react';
import { useStore } from '../stores/store';

export default observer(function FilteringOptionPickSteps() {
	const { branchOfKnowledgeStore, disciplineStore } = useStore();
	const { branchOfKnowledgeSelectionActive, branchOfKnowledgeSelectionCompleted } = branchOfKnowledgeStore;
	const { disciplinesSelectionActive,disciplinesSelectionCompleted} = disciplineStore;
	return (
		<Step.Group ordered attached='top' fluid>
			<Step completed={branchOfKnowledgeSelectionCompleted} active={branchOfKnowledgeSelectionActive}>
				<Step.Content>
					<Step.Title>Вибір області знань</Step.Title>
					<Step.Description></Step.Description>
				</Step.Content>
			</Step>

			<Step completed={disciplinesSelectionCompleted} active={disciplinesSelectionActive}>
				<Step.Content>
					<Step.Title>Вибір дисциплін</Step.Title>
					<Step.Description></Step.Description>
				</Step.Content>
			</Step>

			<Step>
				<Step.Content>
					<Step.Title></Step.Title>
				</Step.Content>
			</Step>
		</Step.Group>
	);
})