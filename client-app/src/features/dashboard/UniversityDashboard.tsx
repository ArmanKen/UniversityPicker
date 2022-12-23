import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { Button, Container, Grid, Sidebar } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import UniversitySelectedSidebar from "./UniversitySelectedSidebar";
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

	return (
		<Sidebar.Pushable>
			<UniversitySidebar visible={visibility} />
			<Sidebar.Pusher>
				<Grid container>
					<Grid.Column >
						<Button
							size="medium"
							color="black"
							inverted
							active
							content={visibility === false ? 'Відкрити фільтри пошуку' : 'Закрити фільтри пошуку'}
							onClick={() => setVisibility(!visibility)}
						/>
						<Button
							size="medium"
							color="black"
							inverted
							active
							content={'Filter by'}
						/>
					</Grid.Column>
				</Grid>
				<UniversityList filterSidebarOpen={visibility} />
			</Sidebar.Pusher>
			<UniversitySelectedSidebar filterSidebarOpen={visibility} />
		</Sidebar.Pushable>
	)
})