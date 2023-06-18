import { observer } from "mobx-react-lite";
import { Grid, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { useEffect } from "react";
import { PagingParams } from "../../../app/models/pagination";
import NotFoundComponent from "../../../app/common/components/NotFoundComponent";
import InfiniteScroll from "react-infinite-scroll-component";
import HigherEducationFacilityReviewsList from "../higherEducationFacilityReviews/HigherEducationFacilityReviewsList";

export interface Props {
	higherEducationFacilityId: string;
}

export default observer(function HigherEducationFacilityReviews({ higherEducationFacilityId }: Props) {
	const { userStore: { user }, reviewStore: { reviews, loadReviews, loadUserReview, pagination,
		reviewLoadingInitial, setPagingParams, userReview } } = useStore();

	useEffect(() => {
		if (reviews.size < 1) {
			loadUserReview(higherEducationFacilityId);
			loadReviews(higherEducationFacilityId);
		}
	}, [loadReviews, reviews.size, higherEducationFacilityId, user, loadUserReview])

	function handleGetNext() {
		if (!reviewLoadingInitial) {
			setPagingParams(new PagingParams(pagination!.currentPage + 1));
			loadReviews(higherEducationFacilityId);
		}
	}

	return (
		<Grid centered stackable stretched>
			<Grid.Row centered>
				<Segment>
					<Header content='Відгуки' textAlign="center" />
				</Segment>
			</Grid.Row>
			<Grid.Row centered>
				<Grid.Column>
					<Segment>
						{!reviewLoadingInitial && reviews.size < 1 ?
							<NotFoundComponent content="Немає відгуків" /> :
							<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 5 }}
								dataLength={reviews.size} next={handleGetNext} loader=''
								hasMore={!reviewLoadingInitial && !!pagination
									&& pagination.currentPage < pagination.totalPages}>
								<HigherEducationFacilityReviewsList reviews={reviews} userReview={userReview}
									higherEducationFacilityId={higherEducationFacilityId} />
							</InfiniteScroll>
						}
					</Segment>
				</Grid.Column>
			</Grid.Row>
		</Grid >
	)
})