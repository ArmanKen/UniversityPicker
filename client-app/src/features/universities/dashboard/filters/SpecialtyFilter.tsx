import { observer } from "mobx-react-lite";
import { Dropdown, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function SpecialtyFilter() {
	const { institutionStore: { institutionLoadingInitial, changeQueryParams },
		menuStore: { specialtiesBaseDropdown, menuLoadingInitial,
			selectedSpecialtiesBase, setSelectedSpecialtiesBase } } = useStore();

	return (
		<Segment
			clearing
			padded='very'
			style={{ paddingBottom: 20, paddingTop: 20 }}>
			<Header
				size='medium'
				textAlign='center'
				content='Спеціальність'
			/>
			<Dropdown
				placeholder='Спеціальність...'
				search
				multiple
				disabled={institutionLoadingInitial || menuLoadingInitial}
				options={specialtiesBaseDropdown}
				value={selectedSpecialtiesBase}
				selection
				fluid
				clearable
				closeOnEscape
				onChange={(e, d) => {
					setSelectedSpecialtiesBase(d.value as string[]);
					changeQueryParams(d.value, 'specialtiesSearch');
				}}
			/>
		</Segment>
	)
})