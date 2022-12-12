import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Button, Container, Grid, Header } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import SpecialtyPick from "./SpecialtyPick";

export default observer(function DisciplineList() {
	const { stepStore, disciplineStore } = useStore()
	const { loadDisciplines, disciplines, updateSelectedDisciplines } = disciplineStore;
	const { setCurrentStep } = stepStore;

	useEffect(() => {
		if (disciplines.length === 0) {
			loadDisciplines();
		}
	}, [disciplines.length, loadDisciplines])


	return (
		<>
			<Header style={{ textAlign: 'center' }}>
				Оберіть дисципліни, які хотіли би вивчати.
			</Header>
			<Button
				color='black'
				size="medium"
				floated='left'>
				Hello
			</Button>
			<Grid container columns={4} stackable textAlign="center" style={{ marginTop: "3em" }}>
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
				{/* <Button
					disabled={selectedDisciplines.size < 1 ? true : false}
					color='black'
					size="big"
					floated='right'
					onClick={() => {
						setStepToActive(disciplineStep);
						setStepToCompleted(branchOfKnowledgeStep);
						setCurrentStep(<SpecialtyPick />)
					}}
					content="Наступний крок"
				/> */}
				<Button
					color='black'
					size="big"
					floated='left'
					onClick={() => {
						setCurrentStep(<SpecialtyPick key={2} />)
					}}
					content="Повернутися до минулого кроку"
				/>
			</Container>
		</>
	);
})
