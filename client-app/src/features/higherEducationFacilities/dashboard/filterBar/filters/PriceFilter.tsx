import { observer } from "mobx-react-lite";
import { Grid, Header, Input, Popup, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function PriceFilter() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams } } = useStore()

	return (
		<Segment
			style={{ paddingLeft: 34, paddingRight: 34 }}>
			<Popup
				disabled={!!higherEducationFacilityQueryParams.specialtyBasesId.length}
				content="Щоб використати ці фільтри потрібно обрати спеціальність"
				trigger={
				<Header
					disabled={!higherEducationFacilityQueryParams.specialtyBasesId.length}
					size='small'
					textAlign='center'
					content='Ціна'
				/>}
			/>
			<Grid textAlign="center">
				<Grid.Row>
					<Grid.Column width={6} floated='left' style={{ padding: 0 }}>
						<Input
							placeholder='Від'
							disabled={!higherEducationFacilityQueryParams.specialtyBasesId.length}
							fluid
							value={higherEducationFacilityQueryParams.minPrice ? higherEducationFacilityQueryParams.minPrice : ''}
							onChange={action((e, d) => {
								if (Number(d.value) || d.value === '')
									higherEducationFacilityQueryParams.minPrice = Number(d.value);
							})}
						/>
					</Grid.Column>
					<Grid.Column width={3} textAlign='center'>
						<Header
							size="huge"
							disabled={!higherEducationFacilityQueryParams.specialtyBasesId.length}
						>
							-
						</Header>
					</Grid.Column>
					<Grid.Column width={6} floated='right' style={{ padding: 0 }}>
						<Input
							placeholder='До'
							disabled={!higherEducationFacilityQueryParams.specialtyBasesId.length}
							fluid
							value={higherEducationFacilityQueryParams.maxPrice ? higherEducationFacilityQueryParams.maxPrice : ''}
							onChange={action((e, d) => {
								if (Number(d.value) || d.value === '')
									higherEducationFacilityQueryParams.maxPrice = Number(d.value);
							})}
						/>
					</Grid.Column>
				</Grid.Row>
			</Grid>
		</Segment>
	)
})