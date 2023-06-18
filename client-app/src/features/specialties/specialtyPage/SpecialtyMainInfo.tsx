import { observer } from "mobx-react-lite";
import { Button, Divider, Grid, Header, Icon, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { Link } from "react-router-dom";
import { Specialty } from "../../../app/models/specialty";

export interface Props {
	specialty: Specialty;
}

export default observer(function SpecialtyMainInfo({ specialty }: Props) {
	const { userStore: { getIsGlobalAdmin, getIsLocalAdmin, isGlobalAdmin, isLocalAdmin } } = useStore();

	getIsGlobalAdmin();
	getIsLocalAdmin(specialty.higherEducationFacilityId);

	return (
		<Grid centered stackable stretched>
			<Button icon circular as={Link}
				style={{ position: 'absolute', top: 25, left: 50 }} color="black"
				to={`/faculty/${specialty.facultyId}`}>
				Повернутися до Факультету
			</Button>
			<Header content={specialty.specialtyBase.name} textAlign="center"
				style={{ marginTop: 20 }} />
			{(isGlobalAdmin || isLocalAdmin) && <Button icon circular as={Link}
				style={{ position: 'absolute', top: 25, right: 50 }}
				to={`/settings/higherEducationFacility/${specialty.higherEducationFacilityId}`}>
				<Icon name='setting' size='large' />
			</Button>}
			<Divider style={{ minWidth: 1000 }} />
			<Grid.Row centered>
				<Segment>
					<Icon name='info' size='big' />
					{' Інформація про Спеціальність: '}
					{specialty.description}
				</Segment>
				<Segment>
					<Icon name='graduation' size='big' />
					{' Освітня ступінь: '}
					{specialty.degree.name}
				</Segment>
				<Segment>
					<Icon name='money' size='big' />
					{' Ціна: '}
					{specialty.priceUAH + ' грн'}
				</Segment>
				<Segment>
					<Icon name='university' size='big' />
					{' Наявність бюджетних місць: '}
					{specialty.budgetAllowed ? " Так" : " Ні"}
				</Segment>
				{/* <Segment>
					{' ECTS кредити: '}
					{specialty.ectsCredits}
				</Segment> */}
				<Segment>
					<Icon name='calendar alternate' size='big' />
					{' Рік: '}
					{specialty.startYear + '/' + specialty.endYear}
				</Segment>
				{/* <Segment>
					<Icon name='language' size='big' />
					{' Мови викладання: '}
					{specialty.languages.map(language =>
						<div key={language.id} style={{ whiteSpace: 'pre-line' }} >{language.name}</div>)}
				</Segment> */}
				<Segment>
					<Icon name='clock outline' size='big' />
					{' Форми навання: '}
					{specialty.studyForms.map(studyForm =>
						<div key={studyForm.id} style={{ whiteSpace: 'pre-line' }} >{studyForm.form}</div>)}
				</Segment>
				<Segment>
					<Icon name='book' size='big' />
					{' ISCED: '}
					{specialty.specialtyBase.isceds.map(isced =>
						<div key={isced.id} style={{ whiteSpace: 'pre-line' }} >{isced.name}</div>)}
				</Segment>
			</Grid.Row>
		</Grid>
	)
})