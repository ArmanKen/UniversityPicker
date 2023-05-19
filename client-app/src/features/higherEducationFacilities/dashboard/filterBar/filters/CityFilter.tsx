import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function CityFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		uiStore: { cities, uiLoadingInitial, } } = useStore();

	return (
		<Segment
			style={{ paddingLeft: 20, paddingRight: 20 }}>
			<Header
				size='small'
				textAlign='center'
				content='Місто'
			/>
			<Dropdown
				placeholder='Місто...'
				search
				multiple
				disabled={uiLoadingInitial}
				options={cities}
				selection
				value={higherEducationFacilityQueryParams.citiesId}
				fluid
				clearable
				closeOnEscape
				onChange={action((e, d) =>
					higherEducationFacilityQueryParams.citiesId = d.value as number[])
				}
			/>
		</Segment>
	)
})