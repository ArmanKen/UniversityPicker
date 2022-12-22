import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { Button, Grid, Sidebar } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import UniversityList from "./UniversityList";
import UniversitySidebar from "./UniversitySidebar";

export default observer(function UniversityDashboard() {
	const { universityStore: { universities, loadUniversities, loadingInitial } } = useStore();
	const [visibility, setVisibility] = useState(false);

	useEffect(() => {
		if (universities.length === 0) {
			loadUniversities();
		}
	}, [universities.length, loadUniversities])

	if (loadingInitial) {
		return <LoadingComponent content='Завантаження фільтрів...' />
	}

	//TODO:Grid.Column>Grid.Row
	return (
		<Sidebar.Pushable style={{ transform: 'none'}}>
			<UniversitySidebar visible={visibility} />
			<Sidebar.Pusher>
				<Grid>
					<Grid.Column>
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
					</Grid.Column>
				</Grid>
				<UniversityList />
			</Sidebar.Pusher>
		</Sidebar.Pushable>
	)
})