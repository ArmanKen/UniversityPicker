import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import InfiniteScroll from "react-infinite-scroll-component";
import { Button, Grid, Segment } from "semantic-ui-react";
import { PagingParams } from "../../../app/models/pagination";
import { useStore } from "../../../app/stores/store";
import HigherEducationFacilityCardList from "../higherEducationFacilityCard/HigherEducationFacilityCardList";
import HigherEducationFacilityFiltersContent from "./filterBar/HigherEducationFacilityFiltersContent";
import UnviersityFiltersHeader from "./filterBar/HigherEducationFacilityFiltersHeader";
import NotFoundComponent from "../../../app/common/components/NotFoundComponent";

export default observer(function HigherEducationFacilityDashboard() {
	const { higherEducationFacilityStore: { higherEducationFacilities, loadHigherEducationFacilitiesController,
		pagination, setPagingParams, higherEducationFacilityLoadingInitial }, modalStore: { openModal } } = useStore();

	useEffect(() => {
		if (higherEducationFacilities.size < 1) loadHigherEducationFacilitiesController();
	}, [loadHigherEducationFacilitiesController, higherEducationFacilities.size])

	function handleGetNext() {
		if (!higherEducationFacilityLoadingInitial) {
			setPagingParams(new PagingParams(pagination!.currentPage + 1));
			loadHigherEducationFacilitiesController();
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
						<HigherEducationFacilityFiltersContent />
					</Segment.Group>
				</Grid.Column>
				<Grid.Column floated="left"
					style={{ marginRight: 10 }}>
					{!higherEducationFacilityLoadingInitial && higherEducationFacilities.size < 1 ?
						<NotFoundComponent content="По заданим фільтрам університети не знайденно" /> :
						<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
							dataLength={higherEducationFacilities.size} next={handleGetNext} loader=''
							hasMore={!higherEducationFacilityLoadingInitial && !!pagination
								&& pagination.currentPage < pagination.totalPages}>
							<HigherEducationFacilityCardList higherEducationFacilities={higherEducationFacilities} />
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
									<HigherEducationFacilityFiltersContent />
								</Segment.Group>, 'small')} />
					{!higherEducationFacilityLoadingInitial && higherEducationFacilities.size < 1 ?
						<NotFoundComponent content="По заданим фільтрам університети не знайденно" /> :
						<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
							dataLength={higherEducationFacilities.size} next={handleGetNext} loader=''
							hasMore={!higherEducationFacilityLoadingInitial && !!pagination
								&& pagination.currentPage < pagination.totalPages}>
							<HigherEducationFacilityCardList higherEducationFacilities={higherEducationFacilities} />
						</InfiniteScroll>
					}
				</Grid.Column>
			</Grid.Row>
		</Grid>
	)
})