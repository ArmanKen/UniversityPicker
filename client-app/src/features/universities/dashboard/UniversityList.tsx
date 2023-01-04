import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import UniversityListCard from "./UniversityListCard";

export default observer(function UniversityList() {
	const { filterStore: { filteredUniversities } } = useStore();

	return (
		<Grid container>
			<Grid.Column largeScreen={12} widescreen={15}>
				<Card.Group itemsPerRow={3}>
					{filteredUniversities.map(university => (
						<UniversityListCard
							key={university.id}
							university={university}
						/>
					))}
				</Card.Group>
			</Grid.Column>
			<Grid.Row verticalAlign="bottom" />
		</Grid>
	)
})