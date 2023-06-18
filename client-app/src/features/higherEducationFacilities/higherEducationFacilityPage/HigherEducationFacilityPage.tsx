import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Divider, Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import HigherEducationFacilityMainInfo from "./HigherEducationFacilityMainInfo";
import LoadingComponent from "../../../app/common/components/LoadingComponent";
import FacultyCardList from "../../faculties/facultyCard/FacultyCardList";
import HigherEducationFacilityGallery from "../higherEducationFacilityGallery/HigherEducationFacilityGallery";
import HigherEducationFacilityContacts from "./HigherEducationFacilityContacts";
import HigherEducationFacilityReviews from "./HigherEducationFacilityReviews";

export default observer(function HigherEducationFacilityPage() {
	const { higherEducationFacilityStore: { loadHigherEducationFacility, clearHigherEducationFacility,
		selectedHigherEducationFacility, higherEducationFacilityLoadingInitial }, photoStore: { clearGallery },
		reviewStore: { clearReviews } } = useStore();
	const { id } = useParams<{ id: string }>();


	useEffect(() => {
		if (id) loadHigherEducationFacility(id);
		return () => {
			clearHigherEducationFacility();
			clearGallery();
			clearReviews();
		}
	}, [clearHigherEducationFacility, id, loadHigherEducationFacility, clearGallery, clearReviews])

	if (higherEducationFacilityLoadingInitial || !selectedHigherEducationFacility)
		return <LoadingComponent content="Завантаження даних ЗВО" />

	return (
		<Grid>
			<Grid.Row>
				<HigherEducationFacilityMainInfo higherEducationFacility={selectedHigherEducationFacility} />
			</Grid.Row>
			<Divider hidden style={{ padding: 0, margin: 0 }} />
			<Grid.Row>
				<FacultyCardList higherEducationFacilityId={selectedHigherEducationFacility.id} />
			</Grid.Row>
			<Divider hidden style={{ padding: 0, margin: 0 }} />
			<Grid.Row>
				<HigherEducationFacilityGallery higherEducationFacilityId={selectedHigherEducationFacility.id} />
			</Grid.Row>
			<Divider hidden style={{ padding: 0, margin: 0 }} />
			<Grid.Row >
				<HigherEducationFacilityContacts higherEducationFacility={selectedHigherEducationFacility} />
			</Grid.Row>
			<Divider hidden style={{ padding: 0, margin: 0 }} />
			<Grid.Row>
				<HigherEducationFacilityReviews higherEducationFacilityId={selectedHigherEducationFacility.id} />
			</Grid.Row>
		</Grid>
	)
})