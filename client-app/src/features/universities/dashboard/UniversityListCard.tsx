import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Icon, Image } from "semantic-ui-react";
import { University } from "../../../app/models/university";
import { useStore } from "../../../app/stores/store";

interface Props {
	university: University
}

export default observer(function UniversityListCard({ university }: Props) {
	const { universityStore: { setUniversity } } = useStore();

	return (
		<Card
			style={{ minWidth: 220, minHeight: 340 }}
			onClick={() => setUniversity(university)}
			raised>
			<Image src='assets/1.png' />
			<Card.Content
				textAlign="center"
				style={{ fontSize: '1.03em', fontWeight: 600 }}>
				<Card.Header>
					{university.name}
				</Card.Header>
				<Card.Description>
					{university.address &&
						university.city &&
						university.region &&
						university.address + ', ' + university.city +
						', ' + university.region}
				</Card.Description>
			</Card.Content>
			<Card.Content
				extra
				textAlign="right">
				<Icon
					name="star"
					color="orange"
					fitted
					style={{ fontSize: '1.2em', fontWeight: 600 }}>
					{' Рейтинг: ' + university.rating.toFixed(1)}
				</Icon>
			</Card.Content>
		</Card>
	)
})