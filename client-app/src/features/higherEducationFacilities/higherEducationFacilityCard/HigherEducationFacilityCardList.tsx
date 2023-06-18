import { observer } from "mobx-react-lite";
import { Card } from "semantic-ui-react";
import HigherEducationFacilityCard from "./HigherEducationFacilityCard";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";

interface Props {
	higherEducationFacilities: Map<string, HigherEducationFacility>
}

export default observer(function HigherEducationFacilityCardList({ higherEducationFacilities }: Props) {
	return (
		<Card.Group itemsPerRow={5} stackable style={{ marginBottom: 10, marginRight: 10, marginLeft: 10 }}>
			{Array.from(higherEducationFacilities.values()).map(higherEducationFacility => (
				<HigherEducationFacilityCard key={higherEducationFacility.id} higherEducationFacility={higherEducationFacility} />
			))}
		</Card.Group>
	)
})