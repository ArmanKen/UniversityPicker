import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react'
import { Dropdown, Header, Segment } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store';

export default observer(function UniversityFilters() {
	const { universityStore, menuStore } = useStore();
	const { universityLoadingInitial, changeQueryParams } = universityStore;
	const { degreeDropdown, menuLoadingInitial, regionsDropdown, selectedCities,
		citiesDropdown, regions, loadRegions, setCitiesDropdown, setSelectedCities,
		branchesOfKnowlegdeDropdown, specialtiesBaseDropdown, loadSpecialtiesBase,
		specialtiesBase, selectedSpecialtiesBase, setSelectedSpecialtiesBase,
		setSpecialtiesBaseDropdown } = menuStore;

	useEffect(() => {
		if (regions.size < 1) loadRegions();
	}, [regions.size, loadRegions])

	useEffect(() => {
		if (specialtiesBase.size < 1) loadSpecialtiesBase();
	}, [specialtiesBase.size, loadSpecialtiesBase])

	return (
		<Segment.Group style={{ minWidth: 150, marginTop: 20 }}>
			<Segment
				clearing
				textAlign="center"
				size="huge">
				Фільтри для пошуку університетів
			</Segment>
			<Segment
				clearing
				padded='very'
				style={{ paddingBottom: 20, paddingTop: 20 }}>
				<Header
					size='medium'
					textAlign='center'
					content='Освітня ступінь'
				/>
				<Dropdown
					placeholder='Освітня ступінь...'
					disabled={universityLoadingInitial}
					options={degreeDropdown}
					selection
					fluid
					clearable
					closeOnChange
					closeOnEscape
					onChange={(e, d) => changeQueryParams(d.value, 'degreeSearch')}
				/>
			</Segment>
			<Segment
				clearing
				padded='very'
				style={{ paddingBottom: 20, paddingTop: 20 }}>
				<Header
					size='medium'
					textAlign='center'
					content='Регіон'
				/>
				<Dropdown
					placeholder='Регіон...'
					search
					multiple
					disabled={universityLoadingInitial || menuLoadingInitial}
					options={regionsDropdown}
					selection
					fluid
					clearable
					closeOnEscape
					onChange={(e, d) => {
						setCitiesDropdown(d.value as number[]);
						changeQueryParams(d.value, 'regionsSearch');
					}}
				/>
			</Segment>
			<Segment
				clearing
				padded='very'
				style={{ paddingBottom: 20, paddingTop: 20 }}>
				<Header
					size='medium'
					textAlign='center'
					content='Місто'
				/>
				<Dropdown
					placeholder='Місто...'
					search
					multiple
					disabled={universityLoadingInitial || menuLoadingInitial}
					options={citiesDropdown}
					selection
					value={selectedCities}
					fluid
					clearable
					closeOnEscape
					onChange={(e, d) => {
						setSelectedCities(d.value as number[]);
						changeQueryParams(d.value, 'citiesSearch');
					}}
				/>
			</Segment>
			<Segment
				clearing
				padded='very'
				style={{ paddingBottom: 20, paddingTop: 20 }}>
				<Header
					size='medium'
					textAlign='center'
					content='Галузь знань'
				/>
				<Dropdown
					placeholder='Галузь знань...'
					search
					multiple
					disabled={universityLoadingInitial || menuLoadingInitial}
					options={branchesOfKnowlegdeDropdown}
					selection
					fluid
					clearable
					closeOnEscape
					onChange={(e, d) => {
						setSpecialtiesBaseDropdown(d.value as string[]);
						changeQueryParams(d.value, 'branchesSearch');
					}}
				/>
			</Segment>
			<Segment
				clearing
				padded='very'
				style={{ paddingBottom: 20, paddingTop: 20 }}>
				<Header
					size='medium'
					textAlign='center'
					content='Спеціальність'
				/>
				<Dropdown
					placeholder='Спеціальність...'
					search
					multiple
					disabled={universityLoadingInitial || menuLoadingInitial}
					options={specialtiesBaseDropdown}
					value={selectedSpecialtiesBase}
					selection
					fluid
					clearable
					closeOnEscape
					onChange={(e, d) => {
						setSelectedSpecialtiesBase(d.value as string[]);
						changeQueryParams(d.value, 'specialtiesSearch');
					}}
				/>
			</Segment>
		</Segment.Group>)
})