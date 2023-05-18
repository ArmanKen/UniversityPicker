import { observer } from "mobx-react-lite";
import { Dropdown, Header, Popup, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function DegreeFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		uiStore: { degrees, uiLoadingInitial } } = useStore();

	return (
		<Segment
			disabled={uiLoadingInitial || !higherEducationFacilityQueryParams.specialtyBasesId.length}
			style={{ paddingLeft: 20, paddingRight: 20 }}>
			<Popup content="Щоб використати ці фільтри потрібно обрати спеціальність" trigger={
				<Header
					textAlign='center'
					content='Освітня ступінь'
					size='small'
				/>}
			/>
			<Dropdown
				disabled={!higherEducationFacilityQueryParams.specialtyBasesId.length}
				placeholder='Освітня ступінь...'
				options={degrees}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={action((e, d) => higherEducationFacilityQueryParams.degreeId = d.value as number)}
			/>
		</Segment>
	)
})