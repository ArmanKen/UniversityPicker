import { observer } from "mobx-react-lite";
import { MapContainer, Marker, TileLayer, Popup } from "react-leaflet";
import { Grid, Header, Icon, Segment } from "semantic-ui-react";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";

export interface Props {
	higherEducationFacility: HigherEducationFacility;
}

export default observer(function HigherEducationFacilityContacts({ higherEducationFacility }: Props) {

	return (
		<Grid centered stackable stretched>
			<Grid.Row centered>
				<Segment>
					<Header textAlign="center" content='Контакти' />
				</Segment>
			</Grid.Row>
			<Grid.Row centered>
				<Grid.Column width={8}>
					<Segment style={{ width: 930, marginLeft: 'auto', marginRight: 0 }} floated="right" clearing attached='top'>
						<Icon name='map marker alternate' size='big' />
						{'Адреса: ' + higherEducationFacility.address + ', '
							+ higherEducationFacility.city.name + ', ' + higherEducationFacility.region.name}
					</Segment>
					<Segment style={{ width: 930, marginLeft: 'auto', marginRight: 0 }} floated="right" clearing attached='top'>
						<Icon name='mobile' size='big' />
						{'Телефон: ' + higherEducationFacility.telephone}
					</Segment>
				</Grid.Column>
				<Grid.Column width={8}>
					<Segment style={{ width: 930 }}>
						<MapContainer center={higherEducationFacility.location ?
							[higherEducationFacility.location.longitude, higherEducationFacility.location.latitude] : [48.414691, 31.012083]}
							scrollWheelZoom={false} zoom={18}
							style={{ width: 900, height: 500, zIndex: 700 }} zoomAnimation={true} maxZoom={18}>
							<TileLayer
								attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
								url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
							/>
							{higherEducationFacility.location &&
								<Marker position={[higherEducationFacility.location.longitude, higherEducationFacility.location.latitude]}>
									<Popup>
										Місце знаходження ЗВО
									</Popup>
								</Marker>
							}
						</MapContainer>
					</Segment>
				</Grid.Column>
			</Grid.Row>
		</Grid >
	)
})