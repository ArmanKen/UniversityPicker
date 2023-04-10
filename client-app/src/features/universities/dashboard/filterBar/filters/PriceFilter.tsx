import { observer } from "mobx-react-lite";
import { Grid, Header, Input, Segment } from "semantic-ui-react";
import { useStore } from "../../../../../app/stores/store";
import { action } from "mobx";

export default observer(function PriceFilter() {
	const { universityStore: { universityQueryParams },
		uiStore: { uiLoadingInitial } } = useStore()

	return (
		<Segment
			disabled={uiLoadingInitial || !universityQueryParams.specialtyBasesId}
			style={{ paddingLeft: 34, paddingRight: 34 }}>
			<Header
				size='small'
				textAlign='center'
				content='Ціна'
			/>
			<Grid textAlign="center">
				<Grid.Row>
					<Grid.Column width={6} floated='left' style={{ padding: 0 }}>
						<Input
							placeholder='Від'
							disabled={uiLoadingInitial || !!universityQueryParams.specialtyBasesId}
							fluid
							value={universityQueryParams.minPrice ? universityQueryParams.minPrice : ''}
							onChange={action((e, d) => {
								if (Number(d.value) || d.value === '')
									universityQueryParams.minPrice = Number(d.value);
							})}
						/>
					</Grid.Column>
					<Grid.Column width={3} textAlign='center'>
						<Header size="huge">
							-
						</Header>
					</Grid.Column>
					<Grid.Column width={6} floated='right' style={{ padding: 0 }}>
						<Input
							placeholder='До'
							disabled={uiLoadingInitial || !!universityQueryParams.specialtyBasesId}
							fluid
							value={universityQueryParams.maxPrice ? universityQueryParams.maxPrice : ''}
							onChange={action((e, d) => {
								if (Number(d.value) || d.value === '')
									universityQueryParams.maxPrice = Number(d.value);
							})}
						/>
					</Grid.Column>
				</Grid.Row>
			</Grid>
		</Segment>
	)
})