import { observer } from "mobx-react-lite";
import { Dropdown, Header, Popup, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function DegreeFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		uiStore: { degrees, uiLoadingInitial } } = useStore();

	return (
		<Segment
			style={{ paddingLeft: 20, paddingRight: 20 }}>
			<Popup
				disabled={!!higherEducationFacilityQueryParams.specialtyBasesId.length}
				content="Щоб використати ці фільтри потрібно обрати спеціальність"
				trigger={
					<Header
						disabled={uiLoadingInitial || !higherEducationFacilityQueryParams.specialtyBasesId.length}
						textAlign='center'
						content='Освітня ступінь'
						size='small'
					/>}
			/>
			<Dropdown
				disabled={uiLoadingInitial || !higherEducationFacilityQueryParams.specialtyBasesId.length}
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