import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Divider, Grid, Header, Icon, Image, Menu, Sidebar } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';
import UniversitySidebarContent from './UniversitySidebarContent';

export default observer(function UniversitySelectedSidebar() {
	const { sidebarStore } = useStore();
	const { universitySidebarOpen, filterSidebarOpen, setUniversitySidebarOpen } = sidebarStore;
	//TODO:contract and budget info,(discipline optional,short info,full info to api)
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
			<UniversitySidebarContent />
		</Sidebar>
	)
})