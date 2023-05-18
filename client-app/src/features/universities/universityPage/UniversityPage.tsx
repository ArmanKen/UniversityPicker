import { observer } from "mobx-react-lite";
import { useEffect, useRef } from "react";
import { useParams } from "react-router-dom";
import { Divider, Grid, Ref } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import HigherEducationFacilityMainInfo from "./HigherEducationFacilityMainInfo";
import useOnScreen from "../../../app/common/hooks/useOnScreen";
import LoadingComponent from "../../../app/common/components/LoadingComponent";
import FacultyCardList from "../../faculties/facultyCard/FacultyCardList";

export default observer(function HigherEducationFacilityPage() {
	const { higherEducationFacilityStore: { loadHigherEducationFacility, clearHigherEducationFacility,
		selectedHigherEducationFacility, higherEducationFacilityLoadingInitial } } = useStore();
	const { id } = useParams<{ id: string }>();
	const facultiesRef = useRef(null);
	const facultiesOnScreen = useOnScreen(facultiesRef, higherEducationFacilityLoadingInitial);
	const galleryRef = useRef(null);
	const galleryOnScreen = useOnScreen(galleryRef, higherEducationFacilityLoadingInitial);
	// const reviewsRef = useRef(null);
	// const reviewsOnScreen = useOnScreen(reviewsRef, higherEducationFacilityLoadingInitial);

	useEffect(() => {
		if (id) loadHigherEducationFacility(id);
		return () => clearHigherEducationFacility();
	}, [clearHigherEducationFacility, id, loadHigherEducationFacility])

	if (higherEducationFacilityLoadingInitial || !selectedHigherEducationFacility)
		return <LoadingComponent content="Завантаження даних про університет" />
	return (
		<Grid>
			<Grid.Row>
				<HigherEducationFacilityMainInfo higherEducationFacility={selectedHigherEducationFacility} />
			</Grid.Row>
			<Ref innerRef={facultiesRef}>
				<Divider hidden style={{ padding: 0, margin: 0 }} />
			</Ref>
			<Grid.Row centered>
				<FacultyCardList facultiesOnScreen={facultiesOnScreen}
					higherEducationFacilityId={selectedHigherEducationFacility.id} />
			</Grid.Row>
			<Ref innerRef={galleryRef}>
				<Divider hidden style={{ padding: 0, margin: 0 }} />
			</Ref>
		</Grid>
	)
})

/* <Tab menu={{
						secondary: true, pointing: true, size: 'huge', style: {
							justifyContent: "center"
						}, stackable: true
					}}
						renderActiveOnly
						defaultActiveIndex={0}
						onTabChange={() => ''} panes={panes}>
					</Tab> */

// const panes = [
// 	{ menuItem: 'Про університет' },
// 	{ menuItem: 'Факультети' },
// 	{ menuItem: 'Галерея' },
// 	{ menuItem: 'Відгуки' },
// 	{ menuItem: 'Контакти' }
// ];