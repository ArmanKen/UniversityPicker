import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { Button, Container, Grid, Sidebar } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import UniversitySidebar from "./UniversitySidebar";
import UniversityList from "./UniversityList";
import FilterSidebar from "./FilterSidebar";

export default observer(function UniversityDashboard() {
	const { universityStore: { universities, loadUniversities, loadingInitial } } = useStore();
	const [filterSidebarOpen, setFilterSidebarOpen] = useState(false);
	const [universitySidebarOpen, setUniversitySidebarOpen] = useState(false);

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
			<FilterSidebar filterSidebarOpen={filterSidebarOpen} />
			<Sidebar.Pusher>
				<Grid container>
					<Grid.Column >
						<Button
							size="medium"
							color="black"
							inverted
							active
							content={filterSidebarOpen === false ? 'Відкрити фільтри пошуку' : 'Закрити фільтри пошуку'}
							onClick={() => setFilterSidebarOpen(!filterSidebarOpen)}
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
				<UniversityList
					setFilterSidebarOpen={setFilterSidebarOpen}
					setUniversitySidebarOpen={setUniversitySidebarOpen}
				/>
			</Sidebar.Pusher>
			<UniversitySidebar
				filterSidebarOpen={filterSidebarOpen}
				setUniversitySidebarOpen={setUniversitySidebarOpen}
				universitySidebarOpen={universitySidebarOpen}
			/>
		</Sidebar.Pushable>
	)
})