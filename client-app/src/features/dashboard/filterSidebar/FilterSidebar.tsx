import { observer } from "mobx-react-lite";
import React from "react";
import { Menu, Sidebar } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import FilterSidebarContent from "./FilterSidebarContent";

export default observer(function FilterSidebar() {
	const { sidebarStore: { filterSidebarOpen } } = useStore();

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
			<FilterSidebarContent />
		</Sidebar>)
})