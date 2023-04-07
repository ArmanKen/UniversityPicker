import { observer } from "mobx-react-lite";
import { Grid, Header, Icon, Image, Segment, Table } from "semantic-ui-react";
import { useStore } from "../../../../app/stores/store";

export default observer(function UniversityShortInfoContent() {
	const { universityStore: { selectedUniversity } } = useStore();

	return (
		<>
			<Header textAlign="center" size="large"
				content={selectedUniversity?.name} />
			<div style={{ position: "relative", display: "flex" }}>
				<Image verticalAlign="top" fluid
					src={(selectedUniversity?.titlePhoto &&
						selectedUniversity.titlePhoto.url) || 'assets/1.png'} />
				<div className="bigSquare" style={{ position: 'absolute', bottom: 0 }}>
					<Icon name='star' size='big'
						style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
						{selectedUniversity?.rating.toFixed(1)}
					</Icon>
				</div>
			</div>
			<Segment style={{ textAlign: 'justify' }} attached='top'
				size='large' padded content={selectedUniversity?.info} />
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
									{selectedUniversity?.region + ', ' +
										selectedUniversity?.city + ', ' +
										selectedUniversity?.address}
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='world' size="big" />
									Веб-Сайт:
								</Table.Cell>
								<Table.Cell>
									<a target="_blank" rel="noopener noreferrer"
										href={'https://' + selectedUniversity?.website}>
										{selectedUniversity?.website}
									</a>
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='mobile' size="big" />
									Телефон:
								</Table.Cell>
								<Table.Cell content={selectedUniversity?.telephone} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='user' size="big" />
									Студентів:
								</Table.Cell>
								<Table.Cell content={selectedUniversity?.studentsCount} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='trophy' size="big" />
									Топ України:
								</Table.Cell>
								<Table.Cell content={selectedUniversity?.ukraineTop ||
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
									{selectedUniversity?.region + ', ' +
										selectedUniversity?.city + ', ' +
										selectedUniversity?.address}
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='world' size="big" />
									Веб-Сайт:
								</Table.Cell>
								<Table.Cell>
									<a target="_blank" rel="noopener noreferrer"
										href={'https://' + selectedUniversity?.website}>
										{selectedUniversity?.website}
									</a>
								</Table.Cell>
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='mobile' size="big" />
									Телефон:
								</Table.Cell>
								<Table.Cell content={selectedUniversity?.telephone} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='user' size="big" />
									Студентів:
								</Table.Cell>
								<Table.Cell content={selectedUniversity?.studentsCount} />
							</Table.Row>
							<Table.Row>
								<Table.Cell >
									<Icon name='trophy' size="big" />
									Топ України:
								</Table.Cell>
								<Table.Cell content={selectedUniversity?.ukraineTop || 'Не входить до топ-200 ВНЗ України'} />
							</Table.Row>
						</Table.Body>
					</Table>
				</Grid.Row>
			</Grid>
		</>
	)
})