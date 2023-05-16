import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import InfiniteScroll from "react-infinite-scroll-component";
import { Button, Grid, Segment } from "semantic-ui-react";
import { PagingParams } from "../../../app/models/pagination";
import { useStore } from "../../../app/stores/store";
import UniversityCardList from "../universityCard/UniversityCardList";
import UniversityFiltersContent from "./filterBar/UniversityFiltersContent";
import UnviersityFiltersHeader from "./filterBar/UniversityFiltersHeader";
import NotFoundComponent from "../../../app/common/components/NotFoundComponent";

export default observer(function UniversityDashboard() {
	const { universityStore: { universities, loadUniversities,
		pagination, setPagingParams, universityLoadingInitial }, modalStore: { openModal } } = useStore();

	useEffect(() => {
		if (universities.size < 1) loadUniversities();
	}, [loadUniversities, universities.size])

	function handleGetNext() {
		if (!universityLoadingInitial) {
			setPagingParams(new PagingParams(pagination!.currentPage + 1));
			loadUniversities();
		}
	}

	return (
		<Grid>
			<Grid.Row only='computer tablet' columns='equal'>
				<Grid.Column
					style={{
						maxWidth: '340px', minWidth: '340px',
						marginRight: 25, marginLeft: 25
					}}>
					<Segment.Group style={{ marginTop: 20 }}>
						<Segment >
							<UnviersityFiltersHeader />
						</Segment>
						<UniversityFiltersContent />
					</Segment.Group>
				</Grid.Column>
				<Grid.Column floated="left"
					style={{ marginRight: 10 }}>
					{!universityLoadingInitial && universities.size < 1 ?
						<NotFoundComponent content="По заданим фільтрам університети не знайденно" /> :
						<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
							dataLength={universities.size} next={handleGetNext} loader=''
							hasMore={!universityLoadingInitial && !!pagination
								&& pagination.currentPage < pagination.totalPages}>
							<UniversityCardList />
						</InfiniteScroll>
					}
				</Grid.Column>
			</Grid.Row>
			<Grid.Row only='mobile'>
				<Grid.Column only="mobile">
					<Button
						style={{ marginTop: 20 }}
						content='Фільтри' color="black"
						size='big' fluid
						onClick={() =>
							openModal(
								<UnviersityFiltersHeader />,
								<Segment.Group>
									<UniversityFiltersContent />
								</Segment.Group>, 'small')} />
					{!universityLoadingInitial && universities.size < 1 ?
						<NotFoundComponent content="По заданим фільтрам університети не знайденно" /> :
						<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
							dataLength={universities.size} next={handleGetNext} loader=''
							hasMore={!universityLoadingInitial && !!pagination
								&& pagination.currentPage < pagination.totalPages}>
							<UniversityCardList />
						</InfiniteScroll>
					}
				</Grid.Column>
			</Grid.Row>
		</Grid>
	)
})