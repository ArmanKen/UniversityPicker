import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function BranchFilter() {
	const { universityStore: { universityQueryParams },
		uiStore: { knowledgeBranches, uiLoadingInitial } } = useStore();

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
					universityQueryParams.knowledgeBranchesId = d.value as string[];
					universityQueryParams.specialtyBasesId = [];
				})}
			/>
		</Segment>
	)
})