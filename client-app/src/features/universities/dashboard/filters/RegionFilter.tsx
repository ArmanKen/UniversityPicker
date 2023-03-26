import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function RegionFilter() {
	const { universityStore: { changeQueryParams, region },
		menuStore: { regionsDropdown, menuLoadingInitial, setCitiesDropdown } } = useStore();

	return (
		<Segment
			padded='very'
			style={{ paddingBottom: 20, paddingTop: 20 }}>
			<Header
				textAlign='center'
				content='Регіон'
				size='small'
			/>
			<Dropdown
				placeholder='Регіон...'
				search
				value={region}
				multiple
				disabled={menuLoadingInitial}
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
	)
})
