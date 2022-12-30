import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Grid } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';

export default observer(function FilterSidebarControllers() {
	const { sidebarStore: { filterSidebarOpen, setFilterSidebarOpen } } = useStore();

	return (
		<Grid container>
			<Grid.Column >
				<Button
					size="big"
					color="black"
					inverted
					active
					content={filterSidebarOpen === false ? 'Відкрити фільтри пошуку' : 'Закрити фільтри пошуку'}
					onClick={() => setFilterSidebarOpen(!filterSidebarOpen)}
				/>
				<Button
					size="big"
					color="black"
					inverted
					active
					content={'Filter by'}
				/>
			</Grid.Column>
		</Grid>
	)
})