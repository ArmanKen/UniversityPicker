import React from "react";
import { Card, Image } from "semantic-ui-react";
import { University } from "../../app/models/university";
import { useStore } from "../../app/stores/store";

interface Props {
	university: University
}

export default function UniversityListCard({ university }: Props) {
	const { specilatyStore: { selectedSpecialty }, universityStore: { getUniversitySelectedSpecialty } } = useStore()

	return (
		<Card >
			<Image src='assets/1.png' size="large"/>
			<Card.Content>
				<Card.Header textAlign="center" >
					<span style={{fontSize:'0.3em !important'}}>{university.name}</span>
				</Card.Header>
				<Card.Description>{university.info}</Card.Description>
			</Card.Content>
			<Card.Content textAlign="right" >
				{selectedSpecialty ?
					'Ціна: ' +	getUniversitySelectedSpecialty(university)?.price + '₴' : ''}
			</Card.Content>
		</Card>
	)
}