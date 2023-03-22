import { observer } from "mobx-react-lite";
import React from "react";
import { Card } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import InstitutionListCard from "./InstitutionListCard";

export default observer(function InstitutionList() {
	const { institutionStore: { institutions } } = useStore();

	return (
		<Card.Group itemsPerRow={4} style={{ marginBottom: 10 }}>
			{Array.from(institutions.values()).map(institution => (
				<InstitutionListCard key={institution.id} institution={institution} />
			))}
		</Card.Group>
	)
})