import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Image } from "semantic-ui-react";
import { University } from "../../app/models/university";
import { useStore } from "../../app/stores/store";

interface Props {
	university: University,
	filterSidebarVisibilityChange: React.Dispatch<React.SetStateAction<boolean>>
}

export default observer(function UniversityListCard({ university, filterSidebarVisibilityChange }: Props) {
	const { specilatyStore: { selectedSpecialty },
		universityStore: { getUniversitySelectedSpecialty, setSelectedUniversity } } = useStore()

	return (
		<Card
			onClick={() => {
				setSelectedUniversity(university);
				filterSidebarVisibilityChange(false);
			}}>
			<Image src='assets/1.png' size="large" />
			<Card.Content>
				<Card.Header textAlign="center">
					{university.name}
				</Card.Header>
				<Card.Description>{university.info}</Card.Description>
			</Card.Content>
			<Card.Content textAlign="right" >
				{selectedSpecialty ?
					'Ціна: ' + getUniversitySelectedSpecialty(university)?.price + '₴' : ''}
			</Card.Content>
		</Card>
	)
})