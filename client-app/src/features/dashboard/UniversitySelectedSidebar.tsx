import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Container, Label, Menu, Sidebar } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

interface Props {
	filterSidebarOpen: boolean;
}

export default observer(function UniversitySelectedSidebar({ filterSidebarOpen }: Props) {
	const { universityStore: { selectedUniversity, setSelectedUniversity } } = useStore();

	return (
		<Sidebar
			as={Menu}
			animation="push"
			inverted
			vertical
			width="wide"
			direction="right"
			className='light-blue'
			visible={!filterSidebarOpen && selectedUniversity !== undefined}
		>
			<Button
				floated='right'
				circular
				className='light-blue'
				size='medium'
				icon='close'
				onClick={() => setSelectedUniversity(undefined)}
			/>
		</Sidebar>
	)
})