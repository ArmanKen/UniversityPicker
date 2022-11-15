import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Button, Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";

export default observer(function BranchOfKnowledgeList() {
	const { branchOfKnowledgeStore } = useStore();
	const { branchesOfKnowledge, loadBranchesOfKnowledge } = branchOfKnowledgeStore;

	useEffect(() => {
		if (branchesOfKnowledge.length <= 1) loadBranchesOfKnowledge();
	}, [branchesOfKnowledge.length, loadBranchesOfKnowledge])

	if (branchOfKnowledgeStore.loadingInitial) return <LoadingComponent content='Loading branches of knowledge...' />


	return (
		<>
			<Grid container columns={3} stackable textAlign="center" style={{ marginTop: "11em" }}>
				{branchesOfKnowledge.map(x => (
					<Grid.Column key={x.id}>
						<Button color='black' content={x.name} />
					</Grid.Column>
				))}
			</Grid>
		</>
	);
})