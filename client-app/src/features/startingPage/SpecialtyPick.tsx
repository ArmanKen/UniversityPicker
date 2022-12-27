import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Button, Container, Dropdown, Header } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';
import BranchOfKnowledgeList from './BranchOfKnowledgeList';
import DisciplinesList from './DisciplinesList';

export default observer(function SpecialtyPick() {
	const { specilatyStore, stepStore } = useStore();
	const { specialties, loadSpecialties, dropdownContent, changeSelectedSpecialty, selectedSpecialty,
		updateSelectedSpecialties, selectedSpecialties } = specilatyStore;

	useEffect(() => {
		if (specialties.length === 0) {
			loadSpecialties();
		}
	}, [specialties.length, loadSpecialties])

	useEffect(() => {
		if (selectedSpecialties.length === 0) {
			updateSelectedSpecialties();
		}
	}, [selectedSpecialties.length, updateSelectedSpecialties])

	return (
		<>
			<Header style={{ textAlign: 'center' }}>
				Оберіть спеціалізацію, якщо ви ще не визначилися, просто перейдіть далі.
			</Header>
			<Dropdown options={dropdownContent}
				value={selectedSpecialty?.code}
				onChange={(e, { value }) => changeSelectedSpecialty(+value!)}
				clearable
				selection
				fluid />
			<Container style={{ marginTop: '7em' }}>
				<Button
					color='black'
					size="big"
					floated='right'
					onClick={() => {
						stepStore.setCurrentStep(<DisciplinesList key={3} />)
					}}
					content="Наступний крок"
				/>
				<Button
					color='black'
					size="big"
					floated='left'
					onClick={() => {
						stepStore.setCurrentStep(<BranchOfKnowledgeList key={1} />)
					}}
					content="Повернутися до минулого кроку"
				/>
			</Container>
		</>
	)
})