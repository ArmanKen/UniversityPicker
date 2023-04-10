import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid, Tab } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import UniversityMainInfo from "./UniversityMainInfo";
import UniversityFaculties from "./UniversityFaculties";
import UniversityGallery from "./UniversityGallery";
import UniversityReviews from "./UniversityReviews";
import UniversityContacts from "./UniversityContacts";

export default observer(function UniversityPage() {
	const { universityStore: { loadUniversity, clearUniversity } } = useStore();
	const { id } = useParams<{ id: string }>();

	useEffect(() => {
		if (id) loadUniversity(id);
		return () => clearUniversity();
	}, [clearUniversity, id, loadUniversity])

	const panes = [
		{ menuItem: 'Про університет', render: () => <UniversityMainInfo /> },
		{ menuItem: 'Факультети', render: () => <UniversityFaculties /> },
		{ menuItem: 'Галлерея', render: () => <UniversityGallery /> },
		{ menuItem: 'Відгуки', render: () => <UniversityReviews /> },
		{ menuItem: 'Контакти', render: () => <UniversityContacts /> },
	];

	return (
		<Grid>
			<Grid.Row>
				<Grid.Column>
					<Tab menu={{
						secondary: true, pointing: true, size: 'huge', style: {
							justifyContent: "center"
						}
					}}
						renderActiveOnly
						defaultActiveIndex={0}
						onTabChange={() => ''} panes={panes}>
					</Tab>
				</Grid.Column>
			</Grid.Row>
		</Grid>
	)
})