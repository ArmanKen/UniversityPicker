import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Container, Grid, Label } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import UniversityListCard from "./UniversityListCard";

interface Props {
	filterSidebarVisibilityChange: React.Dispatch<React.SetStateAction<boolean>>
}

export default observer(function UniversityList({ filterSidebarVisibilityChange }: Props) {
	const { universityStore: { universities } } = useStore();
	return (
		<Grid container>
			<Grid.Column largeScreen={12} widescreen={15}>
				<Card.Group itemsPerRow={3}>
					{universities.map(university => (
						<UniversityListCard
							key={university.id}
							university={university}
							filterSidebarVisibilityChange={filterSidebarVisibilityChange}
						/>
					))}
				</Card.Group>
			</Grid.Column>
			<Grid.Row verticalAlign="bottom" />
		</Grid>
	)
})