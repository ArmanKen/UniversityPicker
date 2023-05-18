import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function BranchFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		uiStore: { knowledgeBranches, uiLoadingInitial, setSpecialtiesBaseDropdown } } = useStore();

	return (
		<Segment
			style={{ paddingLeft: 20, paddingRight: 20 }} >
			<Header
				size='small'
				textAlign='center'
				content='Галузь знань'
			/>
			<Dropdown
				placeholder='Галузь знань...'
				search
				multiple
				disabled={uiLoadingInitial}
				options={Array.from(knowledgeBranches.keys())}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={action((e, d) => {
					higherEducationFacilityQueryParams.knowledgeBranchesId = d.value as string[];
					higherEducationFacilityQueryParams.specialtyBasesId = [];
					setSpecialtiesBaseDropdown(d.value as string[]);
				})}
			/>
		</Segment>
	)
})