import { observer } from "mobx-react-lite";
import { Grid, Header, Icon, Image, Segment, Table } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function HigherEducationFacilityShortInfoContent() {
	const { higherEducationFacilityStore: { selectedHigherEducationFacility } } = useStore();

	return (
		<>
			<Header textAlign="center" size="large"
				content={selectedHigherEducationFacility?.name} />
			<div style={{ position: "relative", display: "flex" }}>
				<Image verticalAlign="top" fluid
					src={selectedHigherEducationFacility?.titlePhoto || 'defaultLogo.png'} />
				<div className="bigSquare" style={{ position: 'absolute', bottom: 0 }}>
					<Icon name='star' size='big'
						style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
						{selectedHigherEducationFacility?.rating.toFixed(1)}
					</Icon>
				</div>
			</div>
			<Segment style={{ textAlign: 'justify' }} attached='top'
				size='large' padded content={selectedHigherEducationFacility?.info} />
			<Grid centered>
				<Grid.Row only='computer tablet'>
					<Table celled textAlign="left">
						<Table.Body>
							<Table.Row>
								<Table.Cell width={5}>
									<Icon name='university' size="big" />
									Адреса:
								</Table.Cell>
								<Table.Cell width={12}>
									{selectedHigherEducationFacility?.region.name + ', ' +
										selectedHigherEducationFacility?.city.name + ', ' +
										selectedHigherEducationFacility?.address}
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='world' size="big" />
									Веб-Сайт:
								</Table.Cell>
								<Table.Cell>
									<a target="_blank" rel="noopener noreferrer"
										href={'https://' + selectedHigherEducationFacility?.website}>
										{selectedHigherEducationFacility?.website}
									</a>
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='mobile' size="big" />
									Телефон:
								</Table.Cell>
								<Table.Cell content={selectedHigherEducationFacility?.telephone} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='user' size="big" />
									Студентів:
								</Table.Cell>
								<Table.Cell content={selectedHigherEducationFacility?.studentsCount} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='trophy' size="big" />
									Топ України:
								</Table.Cell>
								<Table.Cell content={selectedHigherEducationFacility?.ukraineTop ||
									'Не входить до топ-200 ВНЗ України'} />
							</Table.Row>
						</Table.Body>
					</Table>
				</Grid.Row>
				<Grid.Row only='mobile'>
					<Table celled textAlign="center">
						<Table.Body>
							<Table.Row>
								<Table.Cell>
									<Icon name='university' size="big" />
									Адреса:
								</Table.Cell>
								<Table.Cell>
									{selectedHigherEducationFacility?.region.name + ', ' +
										selectedHigherEducationFacility?.city.name + ', ' +
										selectedHigherEducationFacility?.address}
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='world' size="big" />
									Веб-Сайт:
								</Table.Cell>
								<Table.Cell>
									<a target="_blank" rel="noopener noreferrer"
										href={'https://' + selectedHigherEducationFacility?.website}>
										{selectedHigherEducationFacility?.website}
									</a>
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='mobile' size="big" />
									Телефон:
								</Table.Cell>
								<Table.Cell content={selectedHigherEducationFacility?.telephone} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='user' size="big" />
									Студентів:
								</Table.Cell>
								<Table.Cell content={selectedHigherEducationFacility?.studentsCount} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='trophy' size="big" />
									Топ України:
								</Table.Cell>
								<Table.Cell content={selectedHigherEducationFacility?.ukraineTop || 'Не входить до топ-200 ВНЗ України'} />
							</Table.Row>
						</Table.Body>
					</Table>
				</Grid.Row>
			</Grid>
		</>
	)
})