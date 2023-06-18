import { observer } from "mobx-react-lite";
import { Item, Rating } from "semantic-ui-react";
import { Review } from "../../../app/models/review";
import { format } from "date-fns";

interface Props {
	review: Review
}

export default observer(function HigherEducationFacilityReviewItem({ review }: Props) {
	return (
		<Item>
			<Item.Image circular src={review.image || "../assets/149071.png"} size="tiny" />
			<Item.Content>
				<Item.Header content={review.fullName} />
				<Rating size='huge' maxRating={5} style={{ marginLeft: 10 }}
					icon="star" rating={review.rating} disabled/>
				<Item.Meta>
					<p>{format(review.createdAt, 'dd MMM yyyy h:mm aa')}</p>
				</Item.Meta>
				<Item.Description>
					{review.body}
				</Item.Description>
			</Item.Content>
		</Item>)
})