import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import DisciplineToggleButton from "./DisciplineToggleButton";

export default observer(function DisciplineList() {
	const { disciplineStore } = useStore()
	const { disciplines, loadDisciplines, addToSelectedDisciplines, deleteFromSelectedDisciplines } = disciplineStore;

	useEffect(() => {
		if (disciplines.length <= 1) loadDisciplines();
	}, [disciplines.length, loadDisciplines])

	if (disciplineStore.loadingInitial) return <LoadingComponent content='Loading disciplines...' />

	return (
		<>
			<Grid container columns={4} stackable textAlign="center" style={{ marginTop: "11em" }}>
				{disciplines.map(x => (
					<Grid.Column key={x.id}>
						<DisciplineToggleButton
							discipline={x}
							addToSelectedDisciplines={addToSelectedDisciplines}
							deleteFromSelectedDisciplines={deleteFromSelectedDisciplines} />
					</Grid.Column>
				))}
			</Grid>
		</>
	);
})
