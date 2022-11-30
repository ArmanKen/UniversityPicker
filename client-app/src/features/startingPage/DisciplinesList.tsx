import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { Button, Container, Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";

export default observer(function DisciplineList() {
	const { disciplineStore, branchOfKnowledgeStore, specialtyStore } = useStore()
	const { disciplines, loadDisciplines, updateSelectedDisciplines, selectedDisciplines } = disciplineStore;
	const { loadSpecialties, specialties } = specialtyStore;

	useEffect(() => {
		if (disciplines.length <= 1) loadDisciplines();
	}, [disciplines.length, loadDisciplines])

	if (disciplineStore.loadingInitial) return <LoadingComponent content='Loading disciplines...' />


	return (
		<>
			<h1 style={{ textAlign: 'center' }}>
				Оберіть дисципліни, які хотіли би вивчати.
			</h1>
			<Grid container columns={4} stackable textAlign="center" style={{ marginTop: "5em" }}>
				{disciplines.map(x => (
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
					}}
					content="Наступний крок"
				/>
				<Button
					color='black'
					size="big"
					floated='left'
					onClick={() => {
					}}
					as={Link}
					to='/branchesOfKnowledge'
					content="Повернутися до минулого кроку"
				/>
			</Container>
		</>
	);
})
