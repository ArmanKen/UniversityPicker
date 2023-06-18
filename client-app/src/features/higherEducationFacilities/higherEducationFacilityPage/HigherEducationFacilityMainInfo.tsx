import { observer } from "mobx-react-lite";
import { Button, Divider, Grid, Header, Icon, Image, Segment } from "semantic-ui-react";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";
import { useStore } from "../../../app/stores/store";
import { Link } from "react-router-dom";

export interface Props {
	higherEducationFacility: HigherEducationFacility;
}

export default observer(function HigherEducationFacilityMainInfo({ higherEducationFacility }: Props) {
	const { userStore: { getIsGlobalAdmin, getIsLocalAdmin, isGlobalAdmin, isLocalAdmin } } = useStore();

	getIsGlobalAdmin();
	getIsLocalAdmin(higherEducationFacility.id);

	return (
		<Grid centered stackable stretched>
			<Header content={higherEducationFacility.name} textAlign="center"
				style={{ marginTop: 20 }} />
			{(isGlobalAdmin || isLocalAdmin) && <Button icon circular as={Link}
				style={{ position: 'absolute', top: 25, right: 50 }}
				to={`/settings/higherEducationFacility/${higherEducationFacility.id}`}>
				<Icon name='setting' size='large' />
			</Button>}
			<Divider />
			<Grid.Row>
				<Grid.Column width={6}>
					<Image bordered centered
						src={higherEducationFacility.titlePhoto
							|| '../defaultLogo.png'} size='medium' />
				</Grid.Column>
				<Grid.Column textAlign="center" floated="left" width={8}>
					<Segment>
						<Header textAlign="center" content='Про університет' />
						<Divider />
						{higherEducationFacility.info}
					</Segment>
				</Grid.Column>
			</Grid.Row>
			<Grid.Row centered>
				<Segment>
					<Icon name='star' size='big' />
					{'Рейтинг: '}
					{higherEducationFacility.rating.toFixed(1)}
				</Segment>
				<Segment>
					<Icon name='trophy' size="big" />
					{'Топ України: '}
					{higherEducationFacility.ukraineTop || 'Не входить у топ-200 ВНЗ України'}
				</Segment>
				<Segment>
					<Icon name='user' size="big" />
					{'Студентів: '}
					{higherEducationFacility.studentsCount}
				</Segment>
				<Segment>
					<Icon name='world' size="big" />
					{'Веб-Сайт: '}
					<a target="_blank" rel="noopener noreferrer"
						href={'https://' + higherEducationFacility?.website}>
						{higherEducationFacility?.website}
					</a>
				</Segment>
				<Segment>
					<Icon name='certificate' size="big" />
					{'Акредитація: '}
					{(higherEducationFacility.accreditation && higherEducationFacility.accreditation.accreditationLevel) || 'Не вказано'}
				</Segment>
			</Grid.Row>
		</Grid>
	)
})