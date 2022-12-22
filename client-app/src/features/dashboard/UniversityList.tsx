import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Grid } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import UniversityListCard from "./UniversityListCard";

export default observer(function UniversityList() {
	const { universityStore: { universities } } = useStore();
	return (
		<Grid>
			<Grid.Column>
				<Card.Group>
					{universities.map(university => (
						<UniversityListCard key={university.id} university={university} />
					))}
				</Card.Group>
			</Grid.Column>
		</Grid>
	)
})