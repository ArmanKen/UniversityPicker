import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Container, Grid, Header } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import SpecialtyPick from "./SpecialtyPick";

export default observer(function BranchOfKnowledgeList() {
	const { branchOfKnowledgeStore, stepStore } = useStore();
	const { branchesOfKnowledge, updateSelectedBranchOfKnowledge, selectedBranchOfKnowledge } = branchOfKnowledgeStore;

	//TODO styling:Rem?
	return (
		<>
			<Header style={{ textAlign: 'center' }}>
				Оберіть область знань, у якій ви зацікавлені.
			</Header>
			<Grid container columns={3} stackable textAlign="center" style={{ marginTop: "3em" }}>
				{branchesOfKnowledge.map(x => (
					<Grid.Column key={x.code}>
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
						stepStore.setCurrentStep(<SpecialtyPick key={2} />)
					}}
					content="Наступний крок"
				/>
				<Button
					color='black'
					size="big"
					floated='left'
					content="До головного меню"
				/>
			</Container>
		</>
	);
})