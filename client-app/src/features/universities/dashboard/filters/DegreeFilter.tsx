import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function DegreeFilter() {
	const { institutionStore: { changeQueryParams, degree },
		menuStore: { degreeDropdown } } = useStore();

	return (
		<Segment
			padded='very'
			style={{ paddingBottom: 20, paddingTop: 20 }}>
			<Header
				textAlign='center'
				content='Освітня ступінь'
				size='small'
			/>
			<Dropdown
				placeholder='Освітня ступінь...'
				options={degreeDropdown}
				value={degree}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={(e, d) => changeQueryParams(d.value, 'degreeSearch')}
			/>
		</Segment>
	)
})