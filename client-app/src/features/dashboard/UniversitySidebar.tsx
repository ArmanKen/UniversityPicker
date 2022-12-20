import { observer } from "mobx-react-lite";
import React from "react";
import { Menu, Sidebar } from "semantic-ui-react";

interface Props {
	visible: boolean
}

export default observer(function UniversitySidebar({ visible }: Props) {

	return (
		<Sidebar
			as={Menu}
			animation="push"
			inverted
			vertical
			width="wide"
			direction="left"
			visible={visible}
		>
			<Menu.Item>

			</Menu.Item>
		</Sidebar>)
})