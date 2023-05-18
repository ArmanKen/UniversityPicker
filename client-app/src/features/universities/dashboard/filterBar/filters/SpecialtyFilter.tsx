import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function SpecialtyFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		uiStore: { uiLoadingInitial, specialtyBases, } } = useStore();

	return (
		<Segment
			style={{ paddingLeft: 20, paddingRight: 20 }}>
			<Header
				size='small'
				textAlign='center'
				content='Спеціальність'
			/>
			<Dropdown
				placeholder='Спеціальність...'
				search
				multiple
				disabled={uiLoadingInitial}
				options={specialtyBases}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={action((e, d) => {
					higherEducationFacilityQueryParams.specialtyBasesId = d.value as string[];
				})}
			/>
		</Segment>
	)
})