import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Menu, Sidebar } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";
import FilterSidebarContent from "./FilterSidebarContent";

export default observer(function FilterSidebar() {
	const { sidebarStore: { filterSidebarOpen, setFilterSidebarOpen } } = useStore();

	return (
		<Sidebar
			as={Menu}
			animation="push"
			inverted
			vertical
			width="wide"
			direction="left"
			visible={filterSidebarOpen}
			className='sidebar-color'
		>
			<Button
				floated='right'
				circular
				className='sidebar-color'
				size='medium'
				icon='close'
				onClick={() => setFilterSidebarOpen(false)}
			/>
			<FilterSidebarContent />
		</Sidebar>)
})