import { observer } from 'mobx-react-lite';
import react from 'react';
import { Divider, Grid, Header, Icon, Image } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';

export default observer(function UnivesritySidebarContent() {
	const { universityStore: { selectedUniversity: university } } = useStore();

	return (
		<Grid container columns={1}>
			<Grid.Column >
				<Header
					textAlign='center'
					size='medium'
					content={university?.name}
				/>
				<Image
					fluid
					src='/assets/1.png'
					bordered
				/>
				<Divider />
				<Grid.Column floated='left' width={14}>
					<Header as={'h2'} size='small' floated='left'>
						{university?.fullInfo}Some info
					</Header>
				</Grid.Column>
			</Grid.Column>
			<Divider />
			<Grid.Row columns={2}>
				<Grid.Column width={1} >
					<Icon name='building' size='large' fitted />
				</Grid.Column>
				<Grid.Column floated='left' width={14}>
					<Header as={'h2'} size='small' floated='left'>
						{' Адреса: ' + university?.address + ', ' + university?.city}
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2}>
				<Grid.Column width={1} >
					<Icon name='phone' size='large' fitted />
				</Grid.Column>
				<Grid.Column floated='left' width={14}>
					<Header as={'h2'} size='small' floated='left'>
						{' Телефон: ' + university?.telephone}
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2}>
				<Grid.Column width={1} >
					<Icon name='linkify' size='large' fitted />
				</Grid.Column>
				<Grid.Column floated='left' width={14}>
					<Header as={'h2'} size='small' floated='left'>
						{' Cайт університету: '}
						<a target="_blank" href={'https://' + university?.website} rel="noopener noreferrer" >
							{university?.website}
						</a>
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
		</Grid>
	)
})