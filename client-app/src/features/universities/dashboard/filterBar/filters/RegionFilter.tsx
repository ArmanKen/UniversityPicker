import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function RegionFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		uiStore: { regions, uiLoadingInitial } } = useStore();

	return (
		<Segment
			style={{ paddingLeft: 20, paddingRight: 20 }}>
			<Header
				textAlign='center'
				content='Регіон'
				size='small'
			/>
			<Dropdown
				placeholder='Регіон...'
				search
				value={higherEducationFacilityQueryParams.regionsId}
				multiple
				disabled={uiLoadingInitial}
				options={Array.from(regions.keys())}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={action((e, d) => {
					higherEducationFacilityQueryParams.regionsId = d.value as number[];
					higherEducationFacilityQueryParams.citiesId = [];
				})}
			/>
		</Segment>
	)
})
