import React from 'react'
import { Input, Segment } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store';

export default function UniversityFilters() {
	const { universityStore: { changeQueryParams, loadingInitial } } = useStore();
	return (
		<Segment.Group style={{ minWidth: 150 }}>
			<Segment
				clearing
				textAlign="center"
				size="huge">
				Фільтри для пошуку університетів
			</Segment>
			<Segment
				clearing
				padded>
				<Input icon='search' placeholder='Пошук по назві університету...'
					fluid
					loading={loadingInitial}
					onChange={(e, d) => changeQueryParams(d.value)}
				/>
			</Segment>
			<Segment clearing padded='very'></Segment>
			<Segment clearing padded='very'></Segment>
			<Segment clearing padded='very'></Segment>
			<Segment clearing padded='very'></Segment>
			<Segment clearing padded='very'></Segment>
			<Segment clearing padded='very'></Segment>
			<Segment clearing padded='very'></Segment>
		</Segment.Group>)
}