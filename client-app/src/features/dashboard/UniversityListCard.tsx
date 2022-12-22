import React from "react";
import { Card, Image } from "semantic-ui-react";
import { University } from "../../app/models/university";
import { useStore } from "../../app/stores/store";

interface Props {
	university: University
}

export default function UniversityListCard({ university }: Props) {
	const { specilatyStore: { selectedSpecialty }, universityStore: { getUniversitySelectedSpecialty }} = useStore()

	return (
		<Card>
			<Image src='assets/1.png' size="medium" wrapped />
			<Card.Content>
				<Card.Header textAlign="center">{university.name}</Card.Header>
				<Card.Description>{university.info}</Card.Description>
			</Card.Content>
			<Card.Content textAlign="right" extra>
				{selectedSpecialty ?
					'Ціна: ' +
					getUniversitySelectedSpecialty(university)?.price + '₴' : ''}
			</Card.Content>
		</Card>
	)
}