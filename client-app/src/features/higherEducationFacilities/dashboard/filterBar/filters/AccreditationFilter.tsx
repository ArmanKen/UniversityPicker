import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function AccredtitationFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		uiStore: { uiLoadingInitial, accreditations } } = useStore()

	return (
		<Segment
			style={{ paddingLeft: 20, paddingRight: 20 }}>
			<Header
				textAlign='center'
				content='Акредитація'
				size='small'
			/>
			<Dropdown
				fluid
				disabled={uiLoadingInitial}
				placeholder='Акредитація...'
				options={accreditations}
				value={higherEducationFacilityQueryParams.accreditationId || undefined}
				selection
				clearable
				closeOnEscape
				onChange={action((e, d) => higherEducationFacilityQueryParams.accreditationId = d.value as number)}
			/>
		</Segment>
	)
})