import { observer } from "mobx-react-lite";
import { Card, Grid, Header, Loader, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import FacultyCard from "./FacultyCard";
import { useEffect } from "react";
import NotFoundComponent from "../../../app/common/components/NotFoundComponent";

export interface Props {
	universityId: string;
	facultiesOnScreen: boolean;
}

export default observer(function FacultyList({ universityId, facultiesOnScreen }: Props) {
	const { facultyStore: { faculties, loadFaculties, facultyLoadingInitial } } = useStore()

	useEffect(() => {
		if (faculties.size < 1 && facultiesOnScreen)
			loadFaculties(universityId);
	}, [loadFaculties, faculties.size, universityId, facultiesOnScreen])

	return (
		<Grid centered stackable stretched>
			<Grid.Row>
				<Segment compact>
					<Header content='Факультети' textAlign="center" style={{ marginTop: 0, marginBottom: 20 }} />
					{facultyLoadingInitial ? <Loader size="medium" active inline /> : faculties.size > 1 ?
						<Card.Group itemsPerRow={3} stackable style={{ justifyContent: 'center' }}>
							{
								Array.from(faculties.values()).map(facultiy => (
									<FacultyCard key={facultiy.id} faculty={facultiy} />
								))
							}
						</Card.Group > : <NotFoundComponent content="Факультети не знайдено" />
					}
				</Segment>
			</Grid.Row>
		</Grid>
	)
})