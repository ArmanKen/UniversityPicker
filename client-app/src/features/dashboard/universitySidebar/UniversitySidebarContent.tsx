import { observer } from 'mobx-react-lite';
import React from 'react';
import { Button, Divider, Grid, Header, Icon, Image } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';

export default observer(function UnivesritySidebarContent() {
	const { universityStore: { selectedUniversity: university }, specilatyStore: { selectedSpecialty } } = useStore();

	return (
		<Grid container columns={1}>
			<Grid.Column >
				<Header
					textAlign='center'
					size='large'
					content={university?.name}
				/>
			</Grid.Column>
			<Grid.Column style={{padding:0}}>
				<Image
					fluid
					src='/assets/1.png'
				/>
			</Grid.Column>
			<Divider />
			<Grid.Row columns={1} className="custom-grid">
				<Grid.Column width={14} className='centered'>
					<Header as={'h2'} size='medium' textAlign='center'>
						{university?.fullInfo}
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid">
				<Grid.Column width={1} className='centered' >
					<Icon name='building' size='large' fitted />
				</Grid.Column>
				<Grid.Column width={14}>
					<Header as={'h2'} size='medium' floated='left'>
						{' Адреса: ' + (university?.region === university?.city ? '' : university?.region + ', ')
							+ university?.city + ', ' + university?.address}
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid">
				<Grid.Column width={1} className='centered' >
					<Icon name='phone' size='large' fitted />
				</Grid.Column>
				<Grid.Column width={14}>
					<Header as={'h2'} size='medium' floated='left'>
						{' Телефон: ' + university?.telephone}
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid">
				<Grid.Column width={1} className='centered' >
					<Icon name='linkify' size='large' fitted />
				</Grid.Column>
				<Grid.Column width={14}>
					<Header as={'h2'} size='medium' floated='left'>
						{' Cайт університету: '}
						<a target="_blank" href={'https://' + university?.website} rel="noopener noreferrer" >
							{university?.website}
						</a>
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid">
				<Grid.Column width={1} className='centered' >
					<Icon name='trophy' size='large' fitted />
				</Grid.Column>
				<Grid.Column width={14}>
					<Header as={'h2'} size='medium' floated='left'>
						{' Рейтинг ВНЗ України: ' + (university?.countryTopRating === undefined ?
							'Не входить до рейтингу' : university?.countryTopRating)}
					</Header>
				</Grid.Column>
			</Grid.Row>
			{selectedSpecialty && (
				<>
					<Divider />
					<Grid.Row columns={2} className="custom-grid">
						<Grid.Column width={1} className='centered'>
							<Icon name='graduation cap' size='large' fitted />
						</Grid.Column>
						<Grid.Column width={14}>
							<Header as={'h2'} size='medium' floated='left'>
								{selectedSpecialty?.budgetAllowed ? ' Є бюджетні місця' : ' Немає бюджетних місць'}
							</Header>
						</Grid.Column>
					</Grid.Row>
					<Divider />
					<Grid.Row columns={2} className="custom-grid">
						<Grid.Column width={1} className='centered'>
							<Icon name='money' size='large' fitted />
						</Grid.Column>
						<Grid.Column width={14}>
							<Header as={'h2'} size='medium' floated='left'>
								{' Ціна за повний курс бакалавріату: ' + selectedSpecialty?.price + ' ₴'}
							</Header>
						</Grid.Column>
					</Grid.Row>
				</>)
			}
			<Divider />
			<Grid.Row columns={1} className="custom-grid centered">
				<Grid.Column textAlign='center' width={14}>
					<Button active inverted color='black' size='big'>
						{'Повна інформація про університет'}
					</Button>
				</Grid.Column>
			</Grid.Row>
			<Divider style={{ marginBottom: 150 }} />
		</Grid>
	)
})