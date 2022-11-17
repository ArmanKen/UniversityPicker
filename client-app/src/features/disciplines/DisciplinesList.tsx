import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Button, Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";

export default observer(function DisciplineList() {
	const { disciplineStore } = useStore()
	const { disciplines, loadDisciplines, updateSelectedDisciplines } = disciplineStore;

	useEffect(() => {
		if (disciplines.size <= 1) loadDisciplines();
	}, [disciplines.size, loadDisciplines])

	if (disciplineStore.loadingInitial) return <LoadingComponent content='Loading disciplines...' />

	return (
		<>
			<Grid container columns={4} stackable textAlign="center" style={{ marginTop: "11em" }}>
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
		</>
	);
})
