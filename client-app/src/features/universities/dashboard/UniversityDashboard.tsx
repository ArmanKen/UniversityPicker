import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Grid, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import UniversityList from "./UniversityList";
import { PagingParams } from "../../../app/models/pagination";
import UniversityCardGroupPlaceholder from "./UniversityCardGroupPlaceholder";
import UniversityFilters from "./UniversityFilters";
import InfiniteScroll from "react-infinite-scroll-component";

export default observer(function UniversityDashboard() {
	const { universityStore } = useStore();
	const { universities, loadUniversities, pagination, setPagingParams, universityLoadingInitial } = universityStore;

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
			<Grid.Column width={12} >
				<InfiniteScroll
					style={{ overflow: 'hidden', paddingTop: 20 }}
					dataLength={universities.size}
					next={handleGetNext}
					loader=''
					hasMore={!universityLoadingInitial && !!pagination
						&& pagination.currentPage < pagination.totalPages}>
					<UniversityList />
					{universityLoadingInitial && (
						universities.size < 1 ? (
							<>
								< UniversityCardGroupPlaceholder />
								< UniversityCardGroupPlaceholder />
								< UniversityCardGroupPlaceholder />
								< UniversityCardGroupPlaceholder />
							</>) : < UniversityCardGroupPlaceholder />)
					}
					{!universityLoadingInitial && universities.size < 1 &&
						<Segment
							textAlign="center"
							color="grey"
							inverted
							style={{ fontSize: '1.2em' }}
						>
							По заданим фільтрам нічного не знайдено
						</Segment>
					}
				</InfiniteScroll>
			</Grid.Column>
		</Grid>
	)
})