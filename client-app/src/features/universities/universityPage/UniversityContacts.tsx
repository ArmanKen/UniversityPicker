import { observer } from "mobx-react-lite";
import { MapContainer, Marker, TileLayer, Popup } from "react-leaflet";
import { Grid } from "semantic-ui-react";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";

export interface Props {
	higherEducationFacility: HigherEducationFacility;
}

export default observer(function HigherEducationFacilityContacts({ higherEducationFacility }: Props) {
	//TODO scroll ulock on edit mode zoom size + marker
	return (
		<Grid stackable>
			<Grid.Row columns='equal'>
				<Grid.Column>

				</Grid.Column>
				<Grid.Column>
					<MapContainer center={higherEducationFacility.location ?
						[higherEducationFacility.location.latitude, higherEducationFacility.location.longitude] : [48.414691, 31.012083]}
						scrollWheelZoom={false} zoom={6}
						style={{ minWidth: 100, minHeight: 600, zIndex: 700 }}>
						<TileLayer
							attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
							url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
						/>
						{higherEducationFacility.location &&
							<Marker position={[higherEducationFacility.location.latitude, higherEducationFacility.location.longitude]}>
								<Popup>
									A pretty CSS3 popup. <br /> Easily customizable.
								</Popup>
							</Marker>
						}
					</MapContainer>
				</Grid.Column>
			</Grid.Row>
		</Grid >
	)
})