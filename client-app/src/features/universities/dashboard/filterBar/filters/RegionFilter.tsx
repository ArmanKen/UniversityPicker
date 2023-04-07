import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function RegionFilter() {
	const { universityStore: { universityQueryParams },
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
				value={universityQueryParams.regionsId}
				multiple
				disabled={uiLoadingInitial}
				options={Array.from(regions.keys())}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={action((e, d) => {
					universityQueryParams.regionsId = d.value as number[];
					universityQueryParams.citiesId = [];
				})}
			/>
		</Segment>
	)
})
