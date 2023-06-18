import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Divider, Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/common/components/LoadingComponent";
import FacultyMainInfo from "./FacultyMainInfo";
import SpecialtyCardList from "../../specialties/specialtyList/SpecialtyCardList";

export default observer(function FacultyPage() {
	const { facultyStore: { loadFaculty, facultyLoadingInitial,
		selectedFaculty }, specilatyStore: { loadSpecialties, clearSpecialties } } = useStore();
	const { id } = useParams<{ id: string }>();

	useEffect(() => {
		if (id) {
			loadFaculty(id);
			loadSpecialties(id);
		}
		return () => clearSpecialties()
	}, [loadFaculty, id, clearSpecialties, loadSpecialties])

	if (facultyLoadingInitial || !selectedFaculty)
		return <LoadingComponent content="Завантаження даних про Факультет" />

	return (
		<Grid>
			<Grid.Row>
				<FacultyMainInfo faculty={selectedFaculty} />
			</Grid.Row>
			<Divider hidden style={{ padding: 0, margin: 0 }} />
			<Grid.Row>
				<SpecialtyCardList facultyId={selectedFaculty.id} />
			</Grid.Row>
		</Grid>
	)
})