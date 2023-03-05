import { observer } from "mobx-react-lite";
import { Grid, Header, Input, Segment } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function PriceFilter() {
	const { universityStore: { changeQueryParams, minPrice, maxPrice, universityLoadingInitial, specialtyBaseId },
		menuStore: { menuLoadingInitial } } = useStore()

	return (
		<Segment
			disabled={universityLoadingInitial || menuLoadingInitial || !specialtyBaseId}
			clearing
			padded='very'
			style={{ paddingBottom: 20, paddingTop: 20 }}>
			<Header
				size='medium'
				textAlign='center'
				content='Ціна'
			/>
			<Grid textAlign="center">
				<Grid.Row>
					<Grid.Column width={6} floated='left' style={{ padding: 0 }}>
						<Input
							placeholder='Від'
							disabled={universityLoadingInitial || menuLoadingInitial || !specialtyBaseId}
							fluid
							value={minPrice ? minPrice : ''}
							onChange={(e, d) => {
								if (Number(d.value) || d.value === '')
									changeQueryParams(d.value, 'minPriceSearch');
							}}
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
							disabled={universityLoadingInitial || menuLoadingInitial || !specialtyBaseId}
							fluid
							value={maxPrice ? maxPrice : ''}
							onChange={(e, d) => {
								if (Number(d.value) || d.value === '')
									changeQueryParams(d.value, 'maxPriceSearch');
							}}
						/>
					</Grid.Column>
				</Grid.Row>
			</Grid>
		</Segment>
	)
})