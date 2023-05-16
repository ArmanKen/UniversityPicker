import { observer } from "mobx-react-lite";
import { useEffect, useRef } from "react";
import { useParams } from "react-router-dom";
import { Divider, Grid, Ref } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import UniversityMainInfo from "./UniversityMainInfo";
import useOnScreen from "../../../app/common/hooks/useOnScreen";
import LoadingComponent from "../../../app/common/components/LoadingComponent";
import FacultyCardList from "../../faculties/facultyCard/FacultyCardList";

export default observer(function UniversityPage() {
	const { universityStore: { loadUniversity, clearUniversity,
		selectedUniversity, universityLoadingInitial } } = useStore();
	const { id } = useParams<{ id: string }>();
	const facultiesRef = useRef(null);
	const facultiesOnScreen = useOnScreen(facultiesRef, universityLoadingInitial);
	const galleryRef = useRef(null);
	const galleryOnScreen = useOnScreen(galleryRef, universityLoadingInitial);
	// const reviewsRef = useRef(null);
	// const reviewsOnScreen = useOnScreen(reviewsRef, universityLoadingInitial);

	useEffect(() => {
		if (id) loadUniversity(id);
		return () => clearUniversity();
	}, [clearUniversity, id, loadUniversity])

	if (universityLoadingInitial || !selectedUniversity)
		return <LoadingComponent content="Завантаження даних про університет" />
	return (
		<Grid>
			<Grid.Row>
				<UniversityMainInfo university={selectedUniversity} />
			</Grid.Row>
			<Ref innerRef={facultiesRef}>
				<Divider hidden style={{ padding: 0, margin: 0 }} />
			</Ref>
			<Grid.Row centered>
				<FacultyCardList facultiesOnScreen={facultiesOnScreen}
					universityId={selectedUniversity.id} />
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