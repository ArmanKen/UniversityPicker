import React from 'react';
import { Step } from 'semantic-ui-react';

export default function FilteringOptionPickSteps() {

	return (
		<Step.Group ordered attached='top' fluid>
			<Step completed>
				<Step.Content>
					<Step.Title></Step.Title>
					<Step.Description></Step.Description>
				</Step.Content>
			</Step>

			<Step completed>
				<Step.Content>
					<Step.Title></Step.Title>
					<Step.Description></Step.Description>
				</Step.Content>
			</Step>

			<Step active>
				<Step.Content>
					<Step.Title></Step.Title>
				</Step.Content>
			</Step>
		</Step.Group>
	);
}