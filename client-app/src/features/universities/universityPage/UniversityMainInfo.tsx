import { observer } from "mobx-react-lite";
import { Divider, Grid, Header, Icon, Image, Segment } from "semantic-ui-react";
import { University } from "../../../app/models/university";

export interface Props {
	university: University;
}

export default observer(function UniversityMainInfo({ university }: Props) {

	return (
		<Grid centered stackable stretched>
			<Header content={university.name} textAlign="center" style={{ marginTop: 20 }} />
			<Divider />
			<Grid.Row>
				<Grid.Column width={6}>
					<Image bordered centered
						src={university.titlePhoto 
							|| '../defaultLogo.png'} size='medium' />
				</Grid.Column>
				<Grid.Column textAlign="center" floated="left" width={8}>
					<Segment>
						<Header textAlign="center" content='Про університет' />
						<Divider />
						{university.info}
					</Segment>
				</Grid.Column>
			</Grid.Row>
			<Grid.Row centered>
				<Segment>
					<Icon name='star' size='big'/>
						{'Рейтинг: '}
						{university.rating.toFixed(1)}
				</Segment>
				<Segment>
					<Icon name='trophy' size="big" />
					{'Топ України: '}
					{university.ukraineTop || 'Не входить у топ-200 ВНЗ України'}
				</Segment>
				<Segment>
					<Icon name='user' size="big" />
					{'Студентів: '}
					{university.studentsCount}
				</Segment>
				<Segment>
					<Icon name='world' size="big" />
					{'Веб-Сайт: '}
					<a target="_blank" rel="noopener noreferrer"
						href={'https://' + university?.website}>
						{university?.website}
					</a>
				</Segment>
				<Segment>
					<Icon name='certificate' size="big" />
					{'Акредитація: '}
					{(university.accreditation && university.accreditation.accreditationLevel) || 'Не вказано'}
				</Segment>
			</Grid.Row>
		</Grid>
	)
})