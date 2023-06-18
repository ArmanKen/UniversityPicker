import { observer } from "mobx-react-lite";
import { Button, Divider, Grid, Header, Icon, Image, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { Link } from "react-router-dom";
import { Faculty } from "../../../app/models/faculty";

export interface Props {
	faculty: Faculty;
}

export default observer(function FacultyMainInfo({ faculty }: Props) {
	const { userStore: { getIsGlobalAdmin, getIsLocalAdmin, isGlobalAdmin, isLocalAdmin } } = useStore();

	getIsGlobalAdmin();
	getIsLocalAdmin(faculty.higherEducationFacilityId);

	return (
		<Grid centered stackable stretched>
			<Button icon circular as={Link}
				style={{ position: 'absolute', top: 25, left: 50 }} color="black"
				to={`/higherEducationFacility/${faculty.higherEducationFacilityId}`}>
				Повернутися до ЗВО
			</Button>
			<Header content={faculty.name} textAlign="center"
				style={{ marginTop: 20 }} />
			{(isGlobalAdmin || isLocalAdmin) && <Button icon circular as={Link}
				style={{ position: 'absolute', top: 25, right: 50 }}
				to={`/settings/higherEducationFacility/${faculty.higherEducationFacilityId}`}>
				<Icon name='setting' size='large' />
			</Button>}
			<Divider style={{ minWidth: 1000 }} />
			<Grid.Row>
				<Grid.Column width={6}>
					<Image bordered centered
						src={(faculty.facultyPhoto && faculty.facultyPhoto.url)
							|| '../facultyLogo.png'} size='medium' />
				</Grid.Column>
				<Grid.Column textAlign="center" floated="left" width={8}>
					<Segment>
						<Header textAlign="center" content='Про факультет' />
						<Divider />
						{faculty.info}
					</Segment>
				</Grid.Column>
			</Grid.Row>
			<Grid.Row centered>
				<Segment>
					<Icon name='user' size='big' />
					{'Кількість студентів: '}
					{faculty.studentsCount}
				</Segment>
				<Segment>
					<Icon name='book' size="big" />
					{'Області знань: '}
					{faculty.knowledgeBranches.map(knowledgeBranch =>
						<div style={{ whiteSpace: 'pre-line' }} key={knowledgeBranch.id}>{knowledgeBranch.name}</div>) || 'Не вказано'}
				</Segment>
			</Grid.Row>
		</Grid>
	)
})