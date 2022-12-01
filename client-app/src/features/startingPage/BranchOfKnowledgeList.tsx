import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Container, Grid } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import SpecialtyPick from "./SpecialtyPick";

export default observer(function BranchOfKnowledgeList() {
	const { branchOfKnowledgeStore, stepStore } = useStore();
	const { setStepToActive, setStepToCompleted, specilatyStep, branchOfKnowledgeStep, setCurrentStep } = stepStore;
	const { branchesOfKnowledge, updateSelectedBranchOfKnowledge, selectedBranchOfKnowledge } = branchOfKnowledgeStore;

	return (
		<>
			<h1 style={{ textAlign: 'center' }}>
				Оберіть область знань, у якій ви зацікавлені.
			</h1>
			<Grid container columns={3} stackable textAlign="center" style={{ marginTop: "3em" }}>
				{branchesOfKnowledge.map(x => (
					<Grid.Column key={x.id}>
						<Button
							fluid
							color={x.isSelected ? 'black' : 'grey'}
							onClick={() => updateSelectedBranchOfKnowledge(x)}
							content={x.name}
						/>
					</Grid.Column>
				))}
			</Grid>
			<Container style={{ marginTop: '7em' }}>
				<Button
					disabled={selectedBranchOfKnowledge === undefined ? true : false}
					color='black'
					size="big"
					floated='right'
					onClick={() => {
						setStepToActive(specilatyStep);
						setStepToCompleted(branchOfKnowledgeStep);
						setCurrentStep(<SpecialtyPick />)
					}}
					content="Наступний крок"
				/>
			</Container>
		</>
	);
})