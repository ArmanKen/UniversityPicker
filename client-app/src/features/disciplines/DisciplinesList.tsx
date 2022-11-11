import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Button, Grid } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";

export default observer(function DisciplineList() {
	const { disciplineStore } = useStore()
	const { disciplines, loadActivities } = disciplineStore;

	useEffect(() => {
		if (disciplines.length <= 1) loadActivities();
	}, [disciplines.length, loadActivities])

	if (disciplineStore.loadingInitial) return <LoadingComponent content='Loading activities...' />

	//onClick

	return (
		<>
			<Grid container columns={4} doubling stackable textAlign="center" style={{ marginTop: "11em" }}>
				{disciplines.map(x => (
					<Grid.Column>
						<Button toggle inverted content={x.name} />
					</Grid.Column>
				))}
				<Grid.Column>
					<Button toggle inverted content='lol' />
				</Grid.Column>
				<Grid.Column>
					<Button toggle inverted content='lol' />
				</Grid.Column>
				<Grid.Column>
					<Button toggle inverted content='lol' />
				</Grid.Column>
				<Grid.Column>
					<Button toggle inverted content='lol' />
				</Grid.Column>
				<Grid.Column>
					<Button toggle inverted content='lol' />
				</Grid.Column>
			</Grid>
		</>
	);
})