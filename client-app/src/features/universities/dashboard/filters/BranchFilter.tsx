import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function BranchFilter() {
	const { universityStore: { universityLoadingInitial, changeQueryParams },
		menuStore: { branchesOfKnowlegdeDropdown, menuLoadingInitial,
			setSpecialtiesBaseDropdown } } = useStore();

	return (
		<Segment
			clearing
			padded='very'
			style={{ paddingBottom: 20, paddingTop: 20 }}>
			<Header
				size='medium'
				textAlign='center'
				content='Галузь знань'
			/>
			<Dropdown
				placeholder='Галузь знань...'
				search
				multiple
				disabled={universityLoadingInitial || menuLoadingInitial}
				options={branchesOfKnowlegdeDropdown}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={(e, d) => {
					setSpecialtiesBaseDropdown(d.value as string[]);
					changeQueryParams(d.value, 'branchesSearch');
				}}
			/>
		</Segment>
	)
})