import { observer } from "mobx-react-lite";
import { Button, Checkbox, Container, Divider, Dropdown, Grid, Header, Icon, Input } from "semantic-ui-react";
import CustomAccordion from "../../../../app/common/customElements/CustomAccordion";
import { RegionsOfUkraine } from "../../../../app/common/valuesForLists/RegionsOfUkraine";
import { useStore } from "../../../../app/stores/store";

export default observer(function FilterSidebarContent() {
	const { branchOfKnowledgeStore, specilatyStore, filterStore, sidebarStore: { setFilterSidebarOpen } } = useStore();
	const { selectedBranchOfKnowledge, branchesOfKnowledge, updateSelectedBranchOfKnowledge } = branchOfKnowledgeStore;
	const { selectedSpecialties, selectedSpecialty, changeSelectedSpecialty } = specilatyStore;
	const { selectedRegion, changeSelectedRegion } = filterStore;

	return (
		<Grid container columns={1}>
			<Grid.Column className="custom-grid">
				<Header as={'h1'} size='large' className='centered' content='Фільтри пошуку' />
			</Grid.Column>
			<Divider />
			<Grid.Row columns={2} className="custom-grid centered"> {/*{TODO: add grades + pick info } */}
				<Grid.Column width={14} >
					<CustomAccordion
						title='Ступені вищої освіти: '
						content={
							<>
								{['Бакалавріат', 'Магістратура'].map(x => (
									<Checkbox
										className="custom-header"
										radio
										label={x}
										key={x}
									/>
								))}
							</>
						}
					/>
				</Grid.Column>
				<Grid.Column width={1}>
					<Button
						floated='right'
						circular
						className='sidebar-color undobutton'
						size='medium'
						icon='close'
					/>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid centered">
				<Grid.Column width={14}>
					<CustomAccordion
						title={'Галузь знань: ' +
							(selectedBranchOfKnowledge ? selectedBranchOfKnowledge?.name : 'Усі галузі знань')}
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
				<Grid.Column width={1}>
					<Button
						floated='right'
						circular
						className='sidebar-color undobutton'
						size='medium'
						icon='close'
						onClick={() => updateSelectedBranchOfKnowledge(undefined)}
					/>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid centered">
				<Grid.Column width={14}>
					<CustomAccordion
						className={selectedBranchOfKnowledge ? undefined : "disabled title"}
						title={'Спеціалізація: ' +
							(selectedSpecialty ? selectedSpecialty?.name : 'Всі спеціальності')}
						content={
							<>
								{selectedSpecialties.map(specialty => (
									<Checkbox
										className="custom-header centered"
										radio
										key={specialty.code}
										name={'specialties'}
										label={specialty.name}
										value={specialty.code}
										checked={specialty.code === selectedSpecialty?.code ? true : false}
										onChange={() => changeSelectedSpecialty(specialty.code)}
									/>
								))}
							</>
						}
					/>
				</Grid.Column>
				<Grid.Column width={1}>
					<Button
						floated='right'
						circular
						className='sidebar-color undobutton'
						size='medium'
						icon='close'
						onClick={() => changeSelectedSpecialty(undefined)}
					/>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid centered">
				<Grid.Column width={14} >
					<CustomAccordion
						title={'Область: ' + (selectedRegion ? selectedRegion : 'Всі області')}
						content={
							<>
								{RegionsOfUkraine.map(region => (
									<Checkbox
										className="custom-header"
										radio
										key={region}
										name={'regions'}
										label={region}
										value={region}
										checked={region === selectedRegion ? true : false}
										onChange={() => changeSelectedRegion(region)}
									/>
								))}
							</>
						}
					/>
				</Grid.Column>
				<Grid.Column width={1}>
					<Button
						floated='right'
						circular
						className='sidebar-color undobutton'
						size='medium'
						icon='close'
						style={{ marginTop: -9 }}
						onClick={() => changeSelectedRegion(undefined)}
					/>
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid centered" >
				<Grid.Column width={14}>
					<CustomAccordion
						title="Повна ціна за навчання"
						content={
							<Container>
								<Input
									size="mini"
									onChange={(e, data: any) => {
										let value = null;
										if (e.target.value) {
											value = parseInt(e.target.value);
											if (isNaN(value)) {
												console.log('error')
											} else {
												console.log('true')
											}
										}
									}}
									style={{ maxWidth: 95, fontSize: '1.05em' }}
								/>
								<hr
									style={{
										border: ' 2px solid grey',
										borderRadius: '10px',
										background: "grey",
										marginTop: '18px',
										marginLeft: 'auto',
										marginRight: 'auto',
									}}
								/>
								<Input size='mini'
									style={{ maxWidth: 95, fontSize: '1.05em' }} />
							</Container>
						}
					/>
				</Grid.Column>
				<Grid.Column width={1}>
					<Button
						floated='right'
						circular
						className='sidebar-color undobutton'
						size='medium'
						icon='close'
						style={{ marginTop: -9 }}
						onClick={() => changeSelectedRegion(undefined)}
					/>
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
			<Divider style={{ marginBottom: 600 }} />
		</Grid >
	)
})