import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Menu, Sidebar } from 'semantic-ui-react';
import { useStore } from '../../../../app/stores/store';
import UniversitySidebarContent from './UniversitySidebarContent';

export default observer(function UniversitySelectedSidebar() {
	const { sidebarStore } = useStore();
	const { universitySidebarOpen, filterSidebarOpen, setUniversitySidebarOpen } = sidebarStore;
	
	return (
		<Sidebar
			as={Menu}
			animation="push"
			inverted
			vertical
			width="wide"
			direction="right"
			className='sidebar-color'
			visible={!filterSidebarOpen && universitySidebarOpen}
		>
			<Button
				floated='right'
				circular
				className='sidebar-color'
				size='medium'
				icon='close'
				onClick={() => setUniversitySidebarOpen(false)}
			/>
			<UniversitySidebarContent  />
		</Sidebar>
	)
})