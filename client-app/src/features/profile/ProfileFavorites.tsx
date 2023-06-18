import { observer } from "mobx-react-lite";
import { Loader, Segment } from "semantic-ui-react";
import NotFoundComponent from "../../app/common/components/NotFoundComponent";
import InfiniteScroll from "react-infinite-scroll-component";
import HigherEducationFacilityCardList from "../higherEducationFacilities/higherEducationFacilityCard/HigherEducationFacilityCardList";
import { useStore } from "../../app/stores/store";
import { useEffect } from "react";
import { PagingParams } from "../../app/models/pagination";

export default observer(function ProfileFavorites() {
	const { profileStore: { favoriteList, loadFavoriteList,
		pagination, setPagingParams, favoriteListLoadingInitial } } = useStore();

	useEffect(() => {
		if (favoriteList.size < 1) loadFavoriteList();
	}, [loadFavoriteList, favoriteList.size,])

	function handleGetNext() {
		if (!favoriteListLoadingInitial) {
			setPagingParams(new PagingParams(pagination!.currentPage + 1));
			loadFavoriteList();
		}
	}

	return (
		<Segment>
			{favoriteListLoadingInitial && <Loader active={favoriteListLoadingInitial} />}
			{!favoriteListLoadingInitial && favoriteList.size < 1 ?
				<NotFoundComponent content="Немає закладок" /> :
				<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
					dataLength={favoriteList.size} next={handleGetNext} loader=''
					hasMore={!favoriteListLoadingInitial && !!pagination
						&& pagination.currentPage < pagination.totalPages}>
					<HigherEducationFacilityCardList higherEducationFacilities={favoriteList} />
				</InfiniteScroll>
			}
		</Segment>
	)
}) 