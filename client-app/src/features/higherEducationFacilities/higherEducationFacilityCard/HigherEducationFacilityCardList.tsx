import { observer } from "mobx-react-lite";
import { Card } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import HigherEducationFacilityCard from "./HigherEducationFacilityCard";

export default observer(function HigherEducationFacilityCardList() {
	const { higherEducationFacilityStore: { higherEducationFacilities } } = useStore();

	return (
		<Card.Group itemsPerRow={5} stackable style={{ marginBottom: 10, marginRight: 10, marginLeft: 10 }}>
			{Array.from(higherEducationFacilities.values()).map(higherEducationFacility => (
				<HigherEducationFacilityCard key={higherEducationFacility.id} higherEducationFacility={higherEducationFacility} />
			))}
		</Card.Group>
	)
})