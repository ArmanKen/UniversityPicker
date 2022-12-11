import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Container, Grid, Header } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import SpecialtyPick from "./SpecialtyPick";

export default observer(function DisciplineList() {
	const { stepStore } = useStore()
	const { setCurrentStep } = stepStore;

	return (
		<>
			<Header style={{ textAlign: 'center' }}>
				Оберіть дисципліни, які хотіли би вивчати.
			</Header>
			<Grid container columns={4} stackable textAlign="center" style={{ marginTop: "3em" }}>
				{/* {disciplines.map(x => (
					<Grid.Column key={x.id}>
						<Button
							content={x.name}
							onClick={() => updateSelectedDisciplines(x)}
							color={x.isSelected ? 'black' : 'grey'}
							fluid
						/>
					</Grid.Column>
				))} */}
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
						setCurrentStep(<SpecialtyPick key={2}/>)
					}}
					content="Повернутися до минулого кроку"
				/>
			</Container>
		</>
	);
})
