import { observer } from "mobx-react-lite";
import React from "react";
import { Grid, Header, Icon, Image, Modal, Segment, Table } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function InstitutionModalBody() {
	const { institutionStore: { selectedInstitution }, specilatyStore } = useStore();

	return (
		<Modal.Content>
			<Header textAlign="center" size="large"
				content={selectedInstitution?.name} />
			<div style={{ position: "relative", display: "flex" }}>
				<Image verticalAlign="top" fluid
					src={(selectedInstitution?.titlePhoto &&
						selectedInstitution.titlePhoto.url) || 'assets/1.png'} />
				<div className="bigSquare" style={{ position: 'absolute', bottom: 0 }}>
					<Icon name='star' size='big'
						style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
						{selectedInstitution?.rating.toFixed(1)}
					</Icon>
				</div>
			</div>
			<Segment style={{ textAlign: 'justify' }} attached='top'
				size='large' padded content={selectedInstitution?.info} />
			<Grid centered>
				<Grid.Row only='computer tablet'>
					<Table celled textAlign="left">
						<Table.Row>
							<Table.Cell width={5}>
								<Icon name='institution' size="big" />
								Адреса:
							</Table.Cell>
							<Table.Cell width={12}>
								{selectedInstitution?.region + ', ' +
									selectedInstitution?.city + ', ' +
									selectedInstitution?.address}
							</Table.Cell>
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='world' size="big" />
								Веб-Сайт:
							</Table.Cell>
							<Table.Cell>
								<a target="_blank" rel="noopener noreferrer"
									href={'https://' + selectedInstitution?.website}>
									{selectedInstitution?.website}
								</a>
							</Table.Cell>
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='mobile' size="big" />
								Телефон:
							</Table.Cell>
							<Table.Cell content={selectedInstitution?.telephone} />
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='user' size="big" />
								Студентів:
							</Table.Cell>
							<Table.Cell content={selectedInstitution?.studentsCount} />
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='trophy' size="big" />
								Топ України:
							</Table.Cell>
							<Table.Cell content={selectedInstitution?.ukraineTop ||
								'Не входить до топ-200 ВНЗ України'} />
						</Table.Row>
						{ }
					</Table>
				</Grid.Row>
				<Grid.Row only='mobile'>
					<Table celled textAlign="center">
						<Table.Row>
							<Table.Cell>
								<Icon name='institution' size="big" />
								Адреса:
							</Table.Cell>
							<Table.Cell>
								{selectedInstitution?.region + ', ' +
									selectedInstitution?.city + ', ' +
									selectedInstitution?.address}
							</Table.Cell>
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='world' size="big" />
								Веб-Сайт:
							</Table.Cell>
							<Table.Cell>
								<a target="_blank" rel="noopener noreferrer"
									href={'https://' + selectedInstitution?.website}>
									{selectedInstitution?.website}
								</a>
							</Table.Cell>
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='mobile' size="big" />
								Телефон:
							</Table.Cell>
							<Table.Cell content={selectedInstitution?.telephone} />
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='user' size="big" />
								Студентів:
							</Table.Cell>
							<Table.Cell content={selectedInstitution?.studentsCount} />
						</Table.Row>
						<Table.Row>
							<Table.Cell >
								<Icon name='trophy' size="big" />
								Топ України:
							</Table.Cell>
							<Table.Cell content={selectedInstitution?.ukraineTop || 'Не входить до топ-200 ВНЗ України'} />
						</Table.Row>
					</Table>
				</Grid.Row>
			</Grid>
		</Modal.Content>
	)
})