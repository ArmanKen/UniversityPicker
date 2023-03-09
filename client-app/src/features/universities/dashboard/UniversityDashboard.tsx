import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Grid, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import UniversityList from "./UniversityList";
import { PagingParams } from "../../../app/models/pagination";
import UniversityFilters from "./filters/UniversityFilters";
import InfiniteScroll from "react-infinite-scroll-component";

export default observer(function UniversityDashboard() {
	const { universityStore: { universities, loadUniversities,
		pagination, setPagingParams, universityLoadingInitial } } = useStore();

	useEffect(() => {
		if (universities.size < 1) loadUniversities();
	}, [loadUniversities, universities.size])

	function handleGetNext() {
		setPagingParams(new PagingParams(pagination!.currentPage + 1));
		loadUniversities();
	}

	return (
		<Grid >
			<Grid.Row
				only='computer'>
				<Grid.Column
					style={{ minWidth: 355, maxWidth: 400 }}
					widescreen={4}
					largeScreen={4}
					computer={4}
					floated="left">
					<UniversityFilters />
				</Grid.Column>
				<Grid.Column
					widescreen={10}
					largeScreen={10}
					computer={10}
					floated="left">
					<InfiniteScroll
						style={{ overflow: 'hidden', paddingTop: 20 }}
						dataLength={universities.size}
						next={handleGetNext}
						loader=''
						hasMore={!universityLoadingInitial && !!pagination
							&& pagination.currentPage < pagination.totalPages}>
						<UniversityList />
						{!universityLoadingInitial && universities.size < 1 &&
							<Segment
								textAlign="center"
								color="grey"
								inverted
								style={{ fontSize: '1.2em' }}>
								По заданим фільтрам нічного не знайдено
							</Segment>
						}
					</InfiniteScroll>
				</Grid.Column>
			</Grid.Row>
		</Grid>
	)
})