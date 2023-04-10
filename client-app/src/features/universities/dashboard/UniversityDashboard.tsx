import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import InfiniteScroll from "react-infinite-scroll-component";
import { Button, Grid, Segment } from "semantic-ui-react";
import { PagingParams } from "../../../app/models/pagination";
import { useStore } from "../../../app/stores/store";
import UniversityList from "./card/UniversityList";
import UniversityFiltersContent from "./filterBar/UniversityFiltersContent";
import UnviersityFiltersHeader from "./filterBar/UniversityFiltersHeader";

export default observer(function UniversityDashboard() {
	const { universityStore: { universities, loadUniversities,
		pagination, setPagingParams, universityLoadingInitial }, modalStore: { openModal } } = useStore();

	useEffect(() => {
		if (universities.size < 1) loadUniversities();
	}, [loadUniversities, universities.size])

	function handleGetNext() {
		setPagingParams(new PagingParams(pagination!.currentPage + 1));
		loadUniversities();
	}

	return (
		<Grid>
			<Grid.Row only='computer tablet' columns='equal'>
				<Grid.Column
					style={{
						maxWidth: '340px',
						minWidth: '340px',
						marginRight: 25
					}}
					floated="left">
					<Segment.Group style={{ marginTop: 20 }}>
						<Segment >
							<UnviersityFiltersHeader />
						</Segment>
						<UniversityFiltersContent />
					</Segment.Group>
				</Grid.Column>
				<Grid.Column floated="left"
					style={{
						marginRight: 10
					}}>
					<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
						dataLength={universities.size} next={handleGetNext} loader=''
						hasMore={!universityLoadingInitial && !!pagination
							&& pagination.currentPage < pagination.totalPages}>
						<UniversityList />
						{!universityLoadingInitial && universities.size < 1 &&
							<Segment textAlign="center" color="grey" inverted
								style={{ fontSize: '1.2rem' }}>
								По заданим фільтрам нічного не знайдено
							</Segment>}
					</InfiniteScroll>
				</Grid.Column>
			</Grid.Row>
			<Grid.Row only='mobile'>
				<Grid.Column >
					<Button
						content='Фільтри'
						color="black"
						size='big'
						fluid
						onClick={() =>
							openModal(
								<UnviersityFiltersHeader />,
								<Segment.Group>
									<UniversityFiltersContent />
								</Segment.Group>, 'small')} />
					<InfiniteScroll style={{ paddingTop: 20, overflow: 'hidden' }}
						dataLength={universities.size} next={handleGetNext}
						loader='' hasMore={!universityLoadingInitial && !!pagination
							&& pagination.currentPage < pagination.totalPages}>
						<UniversityList />
						{!universityLoadingInitial && universities.size < 1 &&
							<Segment textAlign="center" color="grey" inverted
								style={{ fontSize: '1em' }}>
								По заданим фільтрам нічного не знайдено
							</Segment>}
					</InfiniteScroll>
				</Grid.Column>
			</Grid.Row>
		</Grid>
	)
})