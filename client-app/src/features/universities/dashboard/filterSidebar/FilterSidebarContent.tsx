import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { Button, Checkbox, Container, Divider, Grid, Header, Label } from "semantic-ui-react";
import CustomAccordion from "../../../../app/common/customElements/CustomAccordion";
import CustomInput from "../../../../app/common/customElements/CustomInput";
import { RegionsOfUkraine } from "../../../../app/common/valuesForLists/RegionsOfUkraine";
import LoadingComponent from "../../../../app/layout/LoadingComponent";
import { useStore } from "../../../../app/stores/store";

export default observer(function FilterSidebarContent() {
	const { branchOfKnowledgeStore, specilatyStore, filterStore } = useStore();
	const { selectedBranchOfKnowledge, branchesOfKnowledge,
		updateSelectedBranchOfKnowledge } = branchOfKnowledgeStore;
	const { selectedSpecialties, selectedSpecialty, changeSelectedSpecialty } = specilatyStore;
	const { selectedRegion, changeSelectedRegion, minPrice, maxPrice,
		changeMaxPrice, changeMinPrice, updateUniversityList, loading } = filterStore;

	useEffect(() => {
		updateUniversityList();
	}, [selectedRegion, minPrice, maxPrice,
		selectedSpecialty, selectedBranchOfKnowledge])

	if (loading === true) {
		<LoadingComponent content="Шукаємо університети для вас. Зачекайте будь-ласка кілька секунд." />
	}

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
							<Container fluid>
								<CustomInput
									inputValue={minPrice}
									changeValue={changeMinPrice}
									isNumber={true}
								/>
								<Label
									content='—'
									size="massive"
									className="sidebar-color" />
								<CustomInput
									inputValue={maxPrice}
									changeValue={changeMaxPrice}
									isNumber={true}
								/>
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
				<Grid.Column width={14} textAlign="center">
					<Header className="custom-header" size="medium" content={'У топ 200 ВНЗ України: '} style={{ marginLeft: '-14px' }} />
				</Grid.Column>
				<Grid.Column width={1} style={{ marginLeft: '-80px' }} floated='left'>
					<Checkbox fitted />
				</Grid.Column>
			</Grid.Row>
			<Divider />
			<Grid.Row columns={2} className="custom-grid">
				<Grid.Column width={14} textAlign="center">
					<Header size='medium' className="custom-header" content={'Наявність бюджетних місць: '} style={{ marginLeft: '10px' }} />
				</Grid.Column>
				<Grid.Column floated='left' width={1} style={{ marginLeft: '-30px' }} >
					<Checkbox fitted />
				</Grid.Column>
			</Grid.Row>
			<Divider style={{ marginBottom: 600 }} />
		</Grid >
	)
})