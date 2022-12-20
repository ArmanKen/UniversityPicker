import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import { Button, Card, Grid, GridColumn, Sidebar } from "semantic-ui-react";
import UniversityList from "./UniversityList";
import UniversitySidebar from "./UniversitySidebar";

export default observer(function UniversityDashboard() {
	const [visibility, setVisibility] = useState(false);
	//TODO:Grid.Column>Grid.Row
	return (
		<Sidebar.Pushable style={{ transform: 'none' }}>
			<UniversitySidebar visible={visibility} />
			<Sidebar.Pusher >
				<Grid>
					<Grid.Row >
						<Button
							size="medium"
							color="black"
							inverted
							active
							attached='left'
							floated="left"
							content={visibility === false ? 'Відкрити фільтри пошуку' : 'Закрити фільтри пошуку'}
							onClick={() => setVisibility(!visibility)}
						/>
					</Grid.Row>
					<Grid.Row  >
						<Card.Group itemsPerRow={visibility === true ? 2 : 4}>
							<Card
								image='/images/avatar/large/elliot.jpg'
								header='Elliot Baker'
								meta='Friend'
								description='Elliot is a sound engineer living in Nashville who enjoys playing guitar and hanging with his cat.'
							/>
							<Card
								image='/images/avatar/large/elliot.jpg'
								header='Elliot Baker'
								meta='Friend'
								description='Elliot is a sound engineer living in Nashville who enjoys playing guitar and hanging with his cat.'
							/>
							<Card
								image='/images/avatar/large/elliot.jpg'
								header='Elliot Baker'
								meta='Friend'
								description='Elliot is a sound engineer living in Nashville who enjoys playing guitar and hanging with his cat.'
							/>
							<Card
								image='/images/avatar/large/elliot.jpg'
								header='Elliot Baker'
								meta='Friend'
								description='Elliot is a sound engineer living in Nashville who enjoys playing guitar and hanging with his cat.'
							/>
						</Card.Group>
					</Grid.Row>
				</Grid>

				<UniversityList />
			</Sidebar.Pusher>
		</Sidebar.Pushable>
	)
})