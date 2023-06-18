import { observer } from "mobx-react-lite";
import { Card, Image } from "semantic-ui-react";
import { Photo } from "../../../app/models/photo";

interface Props {
	gallery: Map<string, Photo>;
	setSelectedPhoto: (photo: Photo) => Photo;
}

export default observer(function HigherEducationFacilityCardList({ gallery, setSelectedPhoto }: Props) {
	return (
		<Card.Group itemsPerRow={5} stackable style={{ marginBottom: 10, marginRight: 10, marginLeft: 10, justifyContent: 'center' }}>
			{Array.from(gallery.values()).map(photo => (
				<Card fluid raised
					style={{ minWidth: 250, maxWidth: 400 }}
					key={photo.id} onClick={x => setSelectedPhoto(photo)}>
					<Image fluid src={photo.url} />
				</Card>
			))}
		</Card.Group>
	)
})