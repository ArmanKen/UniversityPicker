import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Grid, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import InstitutionList from "./InstitutionList";
import { PagingParams } from "../../../app/models/pagination";
import InstitutionFilters from "./filters/InstitutionFilters";
import InfiniteScroll from "react-infinite-scroll-component";

export default observer(function InstitutionDashboard() {
	const { institutionStore: { institutions, loadInstitutions,
		pagination, setPagingParams, institutionLoadingInitial } } = useStore();

	useEffect(() => {
		if (institutions.size < 1) loadInstitutions();
	}, [loadInstitutions, institutions.size])

	function handleGetNext() {
		setPagingParams(new PagingParams(pagination!.currentPage + 1));
		loadInstitutions();
	}

	return (
		<Grid >
			<Grid.Row only='computer'>
				<Grid.Column style={{ minWidth: 355, maxWidth: 355 }}
					computer={4} floated="right">
					<InstitutionFilters />
				</Grid.Column>
				<Grid.Column computer={10} floated="left">
					<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
						dataLength={institutions.size} next={handleGetNext}
						loader='' hasMore={!institutionLoadingInitial && !!pagination
							&& pagination.currentPage < pagination.totalPages}>
						<InstitutionList />
						{!institutionLoadingInitial && institutions.size < 1 &&
							<Segment textAlign="center" color="grey" inverted
								style={{ fontSize: '1.2em' }}>
								По заданим фільтрам нічного не знайдено
							</Segment>}
					</InfiniteScroll>
				</Grid.Column>
			</Grid.Row>
		</Grid>
	)
})