import { observer } from 'mobx-react-lite';
import AccreditationFilter from "./filters/AccreditationFilter";
import BranchFilter from './filters/BranchFilter';
import CityFilter from './filters/CityFilter';
import DegreeFilter from './filters/DegreeFilter';
import PriceFilter from './filters/PriceFilter';
import RegionFilter from './filters/RegionFilter';
import SpecialtyFilter from './filters/SpecialtyFilter';
import ToggleFilters from './filters/ToggleFilters';

export default observer(function HigherEducationFacilityFilterContent() {

	return (
		<>
			<AccreditationFilter />
			<RegionFilter />
			<CityFilter />
			<BranchFilter />
			<SpecialtyFilter />
			<DegreeFilter />
			<PriceFilter />
			<ToggleFilters />
		</>
	)
})