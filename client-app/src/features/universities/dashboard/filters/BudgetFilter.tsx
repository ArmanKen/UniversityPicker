import { observer } from "mobx-react-lite";
import { Checkbox, Grid, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function BudgetFilter() {
	const { universityStore: { changeQueryParams, budgetAllowed, ukraineTop, universityLoadingInitial, specialtyBaseId },
		menuStore: { menuLoadingInitial } } = useStore()

	return (
		<Segment
			size="small"
			clearing
			padded='very'
			style={{ paddingBottom: 20, paddingTop: 20 }}>
			<Grid>
				<Grid.Row>
					<Grid.Column
						width={12}
						style={{ paddingRight: 0, paddingLeft: 0 }}
						floated='left'>
						<Header
							size='small'
							disabled={universityLoadingInitial || menuLoadingInitial || !specialtyBaseId}
							content='Тільки з бюджетними місцями'
						/>
					</Grid.Column>
					<Grid.Column
						width={1}
						style={{ paddingRight: 0, paddingLeft: 0 }}
						floated='left'>
						<Checkbox
							toggle
							disabled={universityLoadingInitial || menuLoadingInitial || !specialtyBaseId}
						/>
					</Grid.Column>
				</Grid.Row>
				<Grid.Row>
					<Grid.Column
						width={12}
						style={{ paddingRight: 0, paddingLeft: 0 }}
						floated='left'>
						<Header
							size='small'
							content='Тільки Топ-200 ВНЗ України'
						/>
					</Grid.Column>
					<Grid.Column
						style={{ paddingRight: 0, paddingLeft: 0 }}
						width={1}
						floated='left'>
						<Checkbox
							toggle
						/>
					</Grid.Column>
				</Grid.Row>
			</Grid>
		</Segment>
	)
})