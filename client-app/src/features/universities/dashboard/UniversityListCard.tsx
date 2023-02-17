import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Grid, Icon, Image } from "semantic-ui-react";
import { University } from "../../../app/models/university";
import { useStore } from "../../../app/stores/store";

interface Props {
	university: University
}

export default observer(function UniversityListCard({ university }: Props) {
	const { universityStore: { setSelectedUniversity } } = useStore();

	return (
		<Card style={{ minWidth: 220, minHeight: 340 }}
			onClick={() => setSelectedUniversity(university)}
			color='black'
			raised
		>
			<Image src='assets/1.png' />
			<Card.Content>
				<Card.Header textAlign="center">
					{university.name}
				</Card.Header>
			</Card.Content>
			<Card.Content extra textAlign="right">
				<Icon name="star" color="red" fitted style={{ fontSize: '1.2em', fontWeight: 600 }}>
					{' Рейтинг: ' + university.rating.toFixed(1)}
				</Icon>
			</Card.Content>
		</Card>
	)
})