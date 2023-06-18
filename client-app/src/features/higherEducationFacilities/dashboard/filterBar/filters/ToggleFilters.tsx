import { observer } from "mobx-react-lite";
import { Checkbox, Grid, Header, Popup, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function ToggleFilters() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams } } = useStore()

	return (
		<Segment
			size="small"
			style={{ paddingLeft: 36, paddingRight: 42 }}>
			<Grid>
				<Grid.Row>
					<Grid.Column
						width={12}
						style={{ paddingRight: 0, paddingLeft: 0 }}
						floated='left'>
						<Popup
							disabled={!!higherEducationFacilityQueryParams.specialtyBasesId.length}
							content="Щоб використати ці фільтри потрібно обрати спеціальність"
							trigger={
								<Header
									style={{ marginTop: 2 }}
									size='small'
									disabled={!higherEducationFacilityQueryParams.specialtyBasesId.length}
									content='З бюджетними місцями'
								/>}
						/>
					</Grid.Column>
					<Grid.Column
						width={1}
						style={{ paddingRight: 0, paddingLeft: 0 }}
						floated='left'>
						<Checkbox
							disabled={!higherEducationFacilityQueryParams.specialtyBasesId.length}
							toggle
							checked={higherEducationFacilityQueryParams.budget}
							onChange={action((x, d) => higherEducationFacilityQueryParams.budget = d.checked as boolean)}
						/>
					</Grid.Column>
				</Grid.Row>
				<Grid.Row>
					<Grid.Column
						width={12}
						style={{ paddingRight: 0, paddingLeft: 0 }}
						floated='left'>
						<Header
							style={{ marginTop: 2 }}
							size='small'
							content='У Топ-200 ВНЗ України'
						/>
					</Grid.Column>
					<Grid.Column
						style={{ paddingRight: 0, paddingLeft: 0 }}
						width={1}
						floated='left'>
						<Checkbox
							toggle
							checked={higherEducationFacilityQueryParams.ukraineTop}
							onChange={action((x, d) => higherEducationFacilityQueryParams.ukraineTop = d.checked as boolean)}
						/>
					</Grid.Column>
				</Grid.Row>
			</Grid>
		</Segment>
	)
})