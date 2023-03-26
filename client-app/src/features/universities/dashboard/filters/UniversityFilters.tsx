import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react'
import { Header, Segment } from 'semantic-ui-react'
import { useStore } from '../../../../app/stores/store';
import BranchFilter from './BranchFilter';
import BudgetFilter from './BudgetFilter';
import CityFilter from './CityFilter';
import DegreeFilter from './DegreeFilter';
import PriceFilter from './PriceFilter';
import RegionFilter from './RegionFilter';
import SpecialtyFilter from './SpecialtyFilter';

export default observer(function UniversityFilters() {
	const { menuStore } = useStore();
	const { regions, loadRegions, loadSpecialtiesBase, specialtiesBase } = menuStore;

	useEffect(() => {
		if (regions.size < 1) loadRegions();
	}, [regions.size, loadRegions])

	useEffect(() => {
		if (specialtiesBase.size < 1) loadSpecialtiesBase();
	}, [specialtiesBase.size, loadSpecialtiesBase])

	return (
		<Segment.Group style={{ marginTop: 20 }}>
			<Segment textAlign="center"	>
				<Header size='medium' textAlign='center'
					content='Фільтри для пошуку університетів' />
			</Segment>
			<RegionFilter />
			<CityFilter />
			<BranchFilter />
			<SpecialtyFilter />
			<DegreeFilter />
			<PriceFilter />
			<BudgetFilter />
		</Segment.Group>
	)
})