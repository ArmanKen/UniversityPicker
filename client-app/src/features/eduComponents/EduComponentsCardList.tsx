import { observer } from "mobx-react-lite";
import { Card, Grid, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export default observer(function EduComponentsCardList() {
	const { eduComponentStore: { eduComponents } } = useStore()

	return (
		<Grid centered stackable stretched>
			<Segment>
				<Header style={{ width: 1200 }} textAlign="center">Освітні компоненти</Header>
				<Card.Group centered itemsPerRow={1}>
					{Array.from(eduComponents.values()).map(eduComponent =>
						<Card raised key={eduComponent.id} fluid>
							<Card.Header>{eduComponent.name}</Card.Header>
						</Card>)}
				</Card.Group>
			</Segment>
		</Grid>
	)
})