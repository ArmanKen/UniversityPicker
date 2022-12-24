import { observer } from "mobx-react-lite";
import React from "react";
import { Menu, Sidebar } from "semantic-ui-react";

interface Props {
	filterSidebarOpen: boolean
}

export default observer(function FilterSidebar({ filterSidebarOpen }: Props) {

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
			<Menu.Item>

			</Menu.Item>
		</Sidebar>)
})