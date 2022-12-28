import { observer } from "mobx-react-lite";
import React from "react";
import { Checkbox, Divider, Dropdown, Grid, Header } from "semantic-ui-react";

export default observer(function FilterSidebarContent() {

	return (
		<Grid>
			<Divider />
			<Grid.Row columns={1}>
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' style={{ marginLeft: 15, width: '100%' }}>
						{'Ступенінь вищої освіти: '}
						<Dropdown fluid>

						</Dropdown>
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1}>
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' style={{ marginLeft: 15, width: '100%' }}>
						{'Галузь знань: '}
						<Dropdown fluid>

						</Dropdown>
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1}>
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' style={{ marginLeft: 15, width: '100%' }}>
						{'Cпеціалізація: '}
						<Dropdown fluid>

						</Dropdown>
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1}>
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' style={{ marginLeft: 15, width: '100%' }}>
						{'Область: '}
						<Dropdown fluid>

						</Dropdown>
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1}>
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' style={{ marginLeft: 15, width: '100%' }}>
						{'Ціна за повний курс: '}
					</Header>
					{/*slider*/}
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2}>
				<Grid.Column floated='left' width={15} textAlign="center">
					<Header as={'h2'} size='small'>
						{'У топ 200 ВНЗ України: '}
					</Header>
				</Grid.Column>
				<Grid.Column floated='left' width={1} style={{ marginLeft: -200 }}>
					<Checkbox fitted />
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2}>
				<Grid.Column floated='left' width={15} textAlign="center">
					<Header as={'h2'} size='small'>
						{'Наявність бюджетних місць: '}
					</Header>
				</Grid.Column>
				<Grid.Column floated='left' width={1} style={{ marginLeft: -150 }}>
					<Checkbox fitted />
				</Grid.Column>
			</Grid.Row>
			<Divider style={{ marginBottom: 150 }} />
		</Grid>
	)
})