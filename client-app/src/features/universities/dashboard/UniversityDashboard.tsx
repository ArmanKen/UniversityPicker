import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Divider, Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import InfiniteScroll from "react-infinite-scroller";
import UniversityList from "./UniversityList";
import { PagingParams } from "../../../app/models/pagination";
import UniversityCardGroupPlaceholder from "./UniversityCardGroupPlaceholder";
import UniversityFilters from "./UniversityFilters";

export default observer(function UniversityDashboard() {
	const { universityStore } = useStore();
	const { universities, loadUniversities, pagination, setPagingParams,
		loadingInitial } = universityStore;

	useEffect(() => {
		if (universities.size < 1) loadUniversities();
	}, [loadUniversities, universities.size])

	function handleGetNext() {
		setPagingParams(new PagingParams(pagination!.currentPage + 1));
		loadUniversities();
	}

	return (
		<Grid>
			<Grid.Column floated="left" width={4}>
				<UniversityFilters />
			</Grid.Column>
			<Grid.Column width={12}>
				<InfiniteScroll
					pageStart={0}
					loadMore={handleGetNext}
					hasMore={!loadingInitial && !!pagination &&
						pagination.currentPage < pagination.totalPages}
					initialLoad={false}>
					<UniversityList />
					{loadingInitial &&
						<UniversityCardGroupPlaceholder />}
					<Divider hidden style={{ height: 90 }} />
				</InfiniteScroll>
			</Grid.Column>
		</Grid>
	)
})