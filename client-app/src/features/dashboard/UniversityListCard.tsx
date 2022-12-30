import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Grid, Icon, Image } from "semantic-ui-react";
import { University } from "../../app/models/university";
import { useStore } from "../../app/stores/store";

interface Props {
	university: University
}

export default observer(function UniversityListCard({ university }: Props) {
	const { specilatyStore: { selectedSpecialty }, universityStore, sidebarStore } = useStore()
	const { getUniversitySelectedSpecialty, setSelectedUniversity } = universityStore;
	const { setFilterSidebarOpen, setUniversitySidebarOpen } = sidebarStore;

	return (
		<Card
			onClick={() => {
				setSelectedUniversity(university);
				setFilterSidebarOpen(false);
				setUniversitySidebarOpen(true);
			}}>
			<Image src='assets/1.png' size="large" />
			<Card.Content>
				<Card.Header textAlign="center">
					{university.name}
				</Card.Header>
				<Card.Description textAlign="center" style={{ fontSize: '1.2em', color: 'black' }}>
					{university.shortInfo}
				</Card.Description>
			</Card.Content>
			<Card.Content textAlign="center">
				<Grid columns='equal'>
					<Grid.Column floated="left" textAlign="center" color="black" style={{ fontSize: '1.1em', whiteSpace: 'nowrap' }}>
						{selectedSpecialty ? (
							'Ціна: ' + getUniversitySelectedSpecialty(university)?.price + ' ₴'
						) : ''}
					</Grid.Column>
					<Grid.Column floated='right' textAlign="center" color="black">
						<Icon name="star" color="yellow" fitted style={{ fontSize: '1.1em' }}>
							{' Рейтинг: ' + university.rating}
						</Icon>
					</Grid.Column>
				</Grid>
			</Card.Content>
		</Card>
	)
})