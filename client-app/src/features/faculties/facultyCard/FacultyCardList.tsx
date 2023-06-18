import { observer } from "mobx-react-lite";
import { Card, Grid, Header, Loader, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import FacultyCard from "./FacultyCard";
import { useEffect } from "react";
import NotFoundComponent from "../../../app/common/components/NotFoundComponent";

export interface Props {
	higherEducationFacilityId: string;
}

export default observer(function FacultyList({ higherEducationFacilityId }: Props) {
	const { facultyStore: { faculties, loadFaculties, facultyLoadingInitial } } = useStore()

	useEffect(() => {
		if (faculties.size < 1)
			loadFaculties(higherEducationFacilityId);
	}, [loadFaculties, faculties.size, higherEducationFacilityId])

	return (
		<Grid centered stackable stretched>
			<Grid.Row>
				<Segment compact>
					<Header content='Факультети' textAlign="center" style={{ marginTop: 0, marginBottom: 20 }} />
					{facultyLoadingInitial ? <Loader size="medium" active inline /> : faculties.size > 1 ?
						<Card.Group itemsPerRow={3} stackable style={{ justifyContent: 'center' }}>
							{
								Array.from(faculties.values()).map(faculty => (
									<FacultyCard key={faculty.id} faculty={faculty} />
								))
							}
						</Card.Group > : <NotFoundComponent content="Факультети не знайдено" />
					}
				</Segment>
			</Grid.Row>
		</Grid>
	)
})