import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function DegreeFilter() {
	const { universityStore: { universityQueryParams },
		uiStore: { degrees } } = useStore();

	return (
		<Segment
			style={{ paddingLeft: 20, paddingRight: 20 }}>
			<Header
				textAlign='center'
				content='Освітня ступінь'
				size='small'
			/>
			<Dropdown
				placeholder='Освітня ступінь...'
				options={degrees}
				value={universityQueryParams.degreeId || undefined}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={action((e, d) => universityQueryParams.degreeId = d.value as number)}
			/>
		</Segment>
	)
})