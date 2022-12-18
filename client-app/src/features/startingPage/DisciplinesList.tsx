import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { Button, Container, Grid, Header } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import SpecialtyPick from "./SpecialtyPick";

export default observer(function DisciplineList() {
	const { stepStore: { setCurrentStep }, disciplineStore } = useStore()
	const { loadDisciplines, updateSelectedDisciplines, selectAllDisciplines, disciplines, clearSelectedDisciplines } = disciplineStore;

	//TODO: main menu,modal
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
				onClick={() => selectAllDisciplines()}
				floated='left'>
				Обрати все
			</Button>
			<Button
				color='black'
				size="medium"
				onClick={() => clearSelectedDisciplines()}
				floated='left'>
				Cкасувати вибір
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
				<Button
					color='black'
					size="big"
					floated='right'
					as={Link}
					to='/universities'
					content="Наступний крок"
				/>
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
