import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Container, Divider, Grid, Label, Loader, Menu, Segment, Sidebar } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import InfiniteScroll from "react-infinite-scroller";
import UniversityList from "./UniversityList";
import { PagingParams } from "../../../app/models/pagination";
import LoadingComponent from "../../../app/layout/LoadingComponent";

export default observer(function UniversityDashboard() {
	const { universityStore } = useStore();
	const { universities, loadUniversities, pagination, setPagingParams, loadingInitial, loading } = universityStore;

	useEffect(() => {
		if (universities.size < 1) loadUniversities();
	}, [loadUniversities, universities.size])

	function handleGetNext() {
		setPagingParams(new PagingParams(pagination!.currentPage + 1));
		loadUniversities();
	}

	if (loadingInitial) {
		return <LoadingComponent content="Завантаження університетів" />;
	}

	return (
		<Grid>
			<Grid.Column floated="left" width={4}>
				<Segment.Group >
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
					<Segment clearing padded='very'></Segment>
				</Segment.Group>
			</Grid.Column>
			<Grid.Column floated="left" width={12}>
				<InfiniteScroll
					pageStart={0}
					loadMore={handleGetNext}
					hasMore={!loading && !!pagination && pagination.currentPage < pagination.totalPages}
					initialLoad={false}>
					<UniversityList />
					{loading && (
						<Loader inline='centered' />
					)}
					<Divider hidden style={{ height: 90 }} />
				</InfiniteScroll>
			</Grid.Column>
		</Grid>
	)
})