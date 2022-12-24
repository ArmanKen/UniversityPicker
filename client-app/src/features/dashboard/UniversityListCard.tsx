import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Grid, Icon, Image } from "semantic-ui-react";
import { University } from "../../app/models/university";
import { useStore } from "../../app/stores/store";

interface Props {
	university: University,
	setFilterSidebarOpen: React.Dispatch<React.SetStateAction<boolean>>;
	setUniversitySidebarOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

export default observer(
	function UniversityListCard({ university, setFilterSidebarOpen, setUniversitySidebarOpen }: Props) {
		const { specilatyStore: { selectedSpecialty },
			universityStore: { getUniversitySelectedSpecialty, setSelectedUniversity } } = useStore()

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
					<Card.Description textAlign="center">
						{university.info}
					</Card.Description>
				</Card.Content>
				<Card.Content textAlign="center">
					<Grid columns='equal'>
						<Grid.Column floated="left" textAlign="center" color="black" >
							{
								// selectedSpecialty ?
								'Ціна: ' + university.specialties[1].price + ' ₴'
								// : ''
							}
						</Grid.Column>
						<Grid.Column floated='right' textAlign="center" color="black">
							<Icon name="star" color="yellow" fitted>
								{' ' + university.rating}
							</Icon>
						</Grid.Column>
					</Grid>
				</Card.Content>
			</Card>
		)
	})