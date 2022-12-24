import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Grid } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import UniversityListCard from "./UniversityListCard";

interface Props {
	setFilterSidebarOpen: React.Dispatch<React.SetStateAction<boolean>>;
	setUniversitySidebarOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

export default observer(function UniversityList({ setFilterSidebarOpen, setUniversitySidebarOpen }: Props) {
	const { universityStore: { universities } } = useStore();
	return (
		<Grid container>
			<Grid.Column largeScreen={12} widescreen={15}>
				<Card.Group itemsPerRow={3}>
					{universities.map(university => (
						<UniversityListCard
							setUniversitySidebarOpen={setUniversitySidebarOpen}
							key={university.id}
							university={university}
							setFilterSidebarOpen={setFilterSidebarOpen}
						/>
					))}
				</Card.Group>
			</Grid.Column>
			<Grid.Row verticalAlign="bottom" />
		</Grid>
	)
})