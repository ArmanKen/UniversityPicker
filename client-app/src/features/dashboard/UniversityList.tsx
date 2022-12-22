import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Grid } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import UniversityListCard from "./UniversityListCard";

interface Props {
	sidebarOpen: boolean
}

export default observer(function UniversityList({ sidebarOpen }: Props) {
	const { universityStore: { universities } } = useStore();
	return (
		<Grid>
			<Grid.Column width={sidebarOpen ? 11 : 14}>
				<Card.Group itemsPerRow={sidebarOpen ? 3 : 4}>
					{universities.map(university => (
						<UniversityListCard key={university.id} university={university} />
					))}
					{universities.map(university => (
						<UniversityListCard key={university.id} university={university} />
					))}
					{universities.map(university => (
						<UniversityListCard key={university.id} university={university} />
					))}
					{universities.map(university => (
						<UniversityListCard key={university.id} university={university} />
					))}
				</Card.Group>
			</Grid.Column>
		</Grid>
	)
})