import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Container, Grid, Icon, Image, Segment, Transition } from "semantic-ui-react";
import { University } from "../../../../app/models/university";
import { useStore } from "../../../../app/stores/store";

interface Props {
	university: University
}

export default observer(function UniversityListCard({ university }: Props) {
	const { universityStore: { setUniversity } } = useStore();

	return (
		<Transition
			animation="scale"
			duration={600}
			transitionOnMount={true}>
			<Card
				style={{ width: 250, height: 250 }}
				onClick={() => setUniversity(university)}
				raised>
				<Grid>
					<Grid.Column style={{ position: "relative", display: "flex" }}>
						<Image
							fluid
							style={{ width: 250, height: 150 }}
							src='assets/1.png'
						/>
						<div className="square" style={{ position: 'absolute', bottom: 14 }}>
							<Icon
								name='star'
								size='large'
								style={{ color: 'white', marginTop: 9, marginLeft: 5 }}
							>
								{university.rating.toFixed(1)}
							</Icon>
						</div>
					</Grid.Column>
				</Grid>
				<Card.Content
					textAlign="center"
					style={{ fontSize: '0.9em', fontWeight: 600, height: 150 }}>
					<Card.Header>
						{university.name}
					</Card.Header>
				</Card.Content>
			</Card>
		</Transition>
	)
})