import { observer } from "mobx-react-lite";
import { Item } from "semantic-ui-react";
import { Review } from "../../../app/models/review";
import HigherEducationFacilityReviewFormItem from "./HigherEducationFacilityReviewFormItem";
import HigherEducationFacilityReviewItem from "./HigherEducationFacilityReviewItem";
import { useState } from "react";

interface Props {
	reviews: Map<string, Review>;
	userReview: Review | undefined;
	higherEducationFacilityId: string;
}

export default observer(function HigherEducationFacilityReviewsList({ reviews, userReview,
	higherEducationFacilityId }: Props) {
	const [editMode, setEditMode] = useState(false);

	return (
		<Item.Group style={{ marginBottom: 10, marginRight: 10, marginLeft: 10 }}>
			{userReview &&
				<HigherEducationFacilityReviewFormItem editMode={editMode}
					setEditMode={setEditMode} higherEducationFacilityId={higherEducationFacilityId} review={userReview} />
			}
			{Array.from(reviews.values()).map(review => (
				<HigherEducationFacilityReviewItem review={review} key={review.id} />
			))}
		</Item.Group>
	)
})