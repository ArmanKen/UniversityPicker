import { observer } from "mobx-react-lite";
import { Card } from "semantic-ui-react";
import { Specialty } from "../../../app/models/specialty";
import { Link } from "react-router-dom";

interface Props {
	specialty: Specialty
}

export default observer(function SpecialtyCard({ specialty }: Props) {
	return (
		<Card fluid raised as={Link} to={`/specialty/${specialty.id}`}>
			<Card.Content textAlign="center">
				<Card.Header>{specialty.specialtyBase.name}</Card.Header>
				<Card.Description>{specialty.description}</Card.Description>
			</Card.Content>
		</Card>
	)
})