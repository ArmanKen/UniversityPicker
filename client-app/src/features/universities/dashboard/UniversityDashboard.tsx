import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Sidebar } from "semantic-ui-react";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import { useStore } from "../../../app/stores/store";
import UniversitySidebar from "../../universities/dashboard/universitySidebar/UniversitySidebar";
import UniversityList from "./UniversityList";
import FilterSidebar from "./filterSidebar/FilterSidebar";
import FilterSidebarControllers from "./filterSidebar/FilterSidebarControllers";

export default observer(function UniversityDashboard() {
	const { universityStore, filterStore: { updateUniversityList } } = useStore();
	const { universities, loadUniversities, loadingInitial, } = universityStore;

	useEffect(() => {
		if (universities.length === 0) {
			loadUniversities();
		}
		updateUniversityList();
	}, [universities.length, loadUniversities, updateUniversityList])

	if (loadingInitial) {
		return <LoadingComponent content='Завантаження університетів...' />
	}

	return (
		<Sidebar.Pushable>
			<FilterSidebar />
			<Sidebar.Pusher>
				<FilterSidebarControllers />
				<UniversityList />
			</Sidebar.Pusher>
			<UniversitySidebar />
		</Sidebar.Pushable>
	)
})