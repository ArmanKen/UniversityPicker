import { observer } from "mobx-react-lite";
import { Card } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";
import UniversityListCard from "./UniversityListCard";

export default observer(function UniversityList() {
	const { universityStore: { universities } } = useStore();

	return (
		<Card.Group itemsPerRow={5} stackable style={{ marginBottom: 10,marginRight: 10,marginLeft:10 }}>
			{Array.from(universities.values()).map(university => (
				<UniversityListCard key={university.id} university={university} />
			))}
		</Card.Group>
	)
})