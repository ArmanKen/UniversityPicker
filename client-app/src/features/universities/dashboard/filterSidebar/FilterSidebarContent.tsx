import { observer } from "mobx-react-lite";
import { Checkbox, Divider, Dropdown, Grid, Header} from "semantic-ui-react";
import CustomAccordion from "../../../../app/common/customElements/CustomAccordion";
import { useStore } from "../../../../app/stores/store";

export default observer(function FilterSidebarContent() {
	const { branchOfKnowledgeStore, specilatyStore } = useStore();
	const { selectedBranchOfKnowledge, branchesOfKnowledge, updateSelectedBranchOfKnowledge } = branchOfKnowledgeStore;
	const { } = specilatyStore;

	return (
		<Grid>
			<Divider />
			<Grid.Row columns={1}>
				<Grid.Column width={15} >
					<Header as={'h2'} size='medium' className='centered' content='Фільтри пошуку' />
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1} className="custom-grid">
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small'>
						{'Ступені вищої освіти: '}
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1} className="custom-grid centered">
				<Grid.Column floated='left' width={14}>
					<CustomAccordion
						title='Галузь знань: '
						content={
							<>
								{branchesOfKnowledge.map(branchOfKnowledge => (
									<Checkbox
										className="custom-header "
										radio
										key={branchOfKnowledge.code}
										name={'branchesOfKnowledge'}
										label={branchOfKnowledge.name}
										value={branchOfKnowledge.code}
										checked={branchOfKnowledge.isSelected}
										onChange={() => updateSelectedBranchOfKnowledge(branchOfKnowledge)}
									/>
								))}
							</>
						}
					/>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1} className="custom-grid">
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' className="custom-header" disabled={!selectedBranchOfKnowledge}>
						{'Cпеціалізація: '}
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Grid.Row columns={1} className="custom-grid">
				<Grid.Column width={14} style={{ marginLeft: 20 }}>

				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1} className="custom-grid">
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' className="custom-header">
						{'Область: '}
						<Dropdown>

						</Dropdown>
					</Header>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={1} className="custom-grid">
				<Grid.Column floated='left' width={14} >
					<Header as={'h2'} size='small' floated='left' textAlign='center' className="custom-header">
						{'Ціна за повний курс: '}
					</Header>
					{/*slider*/}
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid">
				<Grid.Column floated='left' width={14} textAlign="center">
					<Header as={'h2'} size='small' className="custom-header">
						{'У топ 200 ВНЗ України: '}
					</Header>
				</Grid.Column>
				<Grid.Column floated='left' width={1} style={{ marginLeft: -180 }}>
					<Checkbox fitted />
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid">
				<Grid.Column floated='left' width={14} textAlign="center">
					<Header as={'h2'} size='small' className="custom-header">
						{'Наявність бюджетних місць: '}
					</Header>
				</Grid.Column>
				<Grid.Column floated='left' width={1} style={{ marginLeft: -130 }}>
					<Checkbox fitted />
				</Grid.Column>
			</Grid.Row>
			<Divider style={{ marginBottom: 150 }} />
		</Grid >
	)
})