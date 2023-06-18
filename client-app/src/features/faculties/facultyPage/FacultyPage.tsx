import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Divider, Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/common/components/LoadingComponent";
import FacultyMainInfo from "./FacultyMainInfo";
import SpecialtyItemsList from "../../specialties/specialtyList/SpecialtyItemsList";

export default observer(function FacultyPage() {
	const { facultyStore: { loadFaculty, facultyLoadingInitial,
		selectedFaculty } } = useStore();
	const { id } = useParams<{ id: string }>();

	useEffect(() => {
		if (id) {
			loadFaculty(id);
		}
	}, [loadFaculty, id])

	if (facultyLoadingInitial || !selectedFaculty)
		return <LoadingComponent content="Завантаження даних ЗВО" />

	return (
		<Grid>
			<Grid.Row>
				<FacultyMainInfo faculty={selectedFaculty} />
			</Grid.Row>
			<Divider hidden style={{ padding: 0, margin: 0 }} />
			<Grid.Row>
				<SpecialtyItemsList facultyId={selectedFaculty.id} />
			</Grid.Row>
		</Grid>
	)
})