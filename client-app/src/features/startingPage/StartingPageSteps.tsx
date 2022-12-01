import { observer } from 'mobx-react-lite';
import React from 'react';
import { Step } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

export default observer(function StartingPageSteps() {
	const { stepStore } = useStore();
	const { branchOfKnowledgeStep, specilatyStep, disciplineStep } = stepStore;

	return (
		<Step.Group ordered attached='top' fluid>
			<Step
				completed={branchOfKnowledgeStep.completed}
				active={branchOfKnowledgeStep.active}
				disabled={branchOfKnowledgeStep.disabled}>
				<Step.Content>
					<Step.Title>Вибір області знань</Step.Title>
				</Step.Content>
			</Step>
			<Step
				completed={specilatyStep.completed}
				active={specilatyStep.active}
				disabled={specilatyStep.disabled}>
				<Step.Content>
					<Step.Title>Вибір спеціалізації</Step.Title>
				</Step.Content>
			</Step>
			<Step
				completed={disciplineStep.completed}
				active={disciplineStep.active}
				disabled={disciplineStep.disabled}>
				<Step.Content>
					<Step.Title>Вибір дисциплін</Step.Title>
				</Step.Content>
			</Step>
		</Step.Group>
	);
})