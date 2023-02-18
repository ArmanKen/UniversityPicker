import { observer } from "mobx-react-lite";
import React from "react";
import { Card } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import UniversityListCard from "./UniversityListCard";

export default observer(function UniversityList() {
	const { universityStore: { universities } } = useStore();

	return (
		<Card.Group doubling itemsPerRow={4} style={{ marginBottom: 10 }}>
			{Array.from(universities.values()).map(university => (
				<UniversityListCard
					key={university.id}
					university={university}
				/>
			))}
		</Card.Group>
	)
})