import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { Button, Container, Grid, Label } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";

export default observer(function DisciplineList() {
	const { disciplineStore, branchOfKnowledgeStore } = useStore()
	const { disciplines, loadDisciplines, updateSelectedDisciplines,
		deactivateDisciplinesSelection, completeDisciplinesSelection, selectedDisciplines } = disciplineStore;
	const { activateBranchOfKnowledgeSelection } = branchOfKnowledgeStore;

	useEffect(() => {
		if (disciplines.size <= 1) loadDisciplines();
	}, [disciplines.size, loadDisciplines])

	if (disciplineStore.loadingInitial) return <LoadingComponent content='Loading disciplines...' />

	return (
		<>
			<h1 style={{textAlign:'center'}}>
				Оберіть дисципліни, які хотіли би вивчати.
			</h1>
			<Grid container columns={4} stackable textAlign="center" style={{ marginTop: "5em" }}>
				{Array.from(disciplines.values()).map(x => (
					<Grid.Column key={x.id}>
						<Button
							content={x.name}
							onClick={() => updateSelectedDisciplines(x)}
							color={x.isSelected ? 'black' : 'grey'}
							fluid
						/>
					</Grid.Column>
				))}
			</Grid>
			<Container style={{ marginTop: '7em' }}>
				<Button
					disabled={selectedDisciplines.size < 1 ? true : false}
					color='black'
					size="big"
					floated='right'
					onClick={() => {
						completeDisciplinesSelection();
					}}
					content="Наступний крок"
				/>
				<Button
					color='black'
					size="big"
					floated='left'
					onClick={() => {
						activateBranchOfKnowledgeSelection();
						deactivateDisciplinesSelection();
					}}
					as={Link}
					to='/branchesOfKnowledge'
					content="Повернутися до минулого кроку"
				/>
			</Container>
		</>
	);
})
