import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function CityFilter() {
	const { institutionStore: { institutionLoadingInitial, changeQueryParams },
		menuStore: { citiesDropdown, menuLoadingInitial,
			selectedCities, setSelectedCities } } = useStore();

	return (
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
				disabled={institutionLoadingInitial || menuLoadingInitial}
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
	)
})