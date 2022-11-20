import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { Button, Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";

export default observer(function BranchOfKnowledgeList() {
	const { branchOfKnowledgeStore, disciplineStore } = useStore();
	const { branchesOfKnowledge, loadBranchesOfKnowledge, updateSelectedBranchOfKnowledge, completeBranchOfKnowledgeSelection, selectedBranchOfKnowledge } = branchOfKnowledgeStore;
	const { activateBranchOfKnowledgeSelection } = disciplineStore;

	useEffect(() => {
		if (branchesOfKnowledge.length <= 1) loadBranchesOfKnowledge();
	}, [branchesOfKnowledge.length, loadBranchesOfKnowledge])

	if (branchOfKnowledgeStore.loadingInitial) return <LoadingComponent content='Loading branches of knowledge...' />

	return (
		<>
			<Grid container columns={3} stackable textAlign="center">
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
			<Button
				disabled={selectedBranchOfKnowledge === undefined ? true : false}
				color='black'
				size="big"
				style={{ marginTop: '7em' }}
				floated='right'
				onClick={() => {
					completeBranchOfKnowledgeSelection();
					activateBranchOfKnowledgeSelection();
				}}
				as={Link}
				to='/disciplines'
				content="Наступний крок"
			/>
		</>
	);
})