import { observer } from "mobx-react-lite";
import React from "react";
import { Grid, Header, Icon, Image, Modal, Segment, Table } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function UniversityModalBody() {
	const { universityStore: { selectedUniversity } } = useStore();

	return (
		<Modal.Content>
			<Header textAlign="center" size="large"
				content={selectedUniversity?.name} />
			<Image verticalAlign="top" fluid
				src={(selectedUniversity?.titlePhoto &&
					selectedUniversity.titlePhoto.url) || 'assets/1.png'}
			/>
			<Segment style={{ textAlign: 'justify' }} attached='top'
				size='large' padded content={selectedUniversity?.info}
			/>
			<Grid centered>
				<Grid.Row only='computer'>
					<Table celled textAlign="left">
						<Table.Row>
							<Table.Cell width={4}>
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
							<Table.Cell content={selectedUniversity?.ukraineTop || 'Не входить до топ-200 ВНЗ України'} />
						</Table.Row>
					</Table>
				</Grid.Row>
				<Grid.Row only='tablet'>
					<Table celled textAlign="left">
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
							<Table.Cell content={selectedUniversity?.ukraineTop || 'Не входить до топ-200 ВНЗ України'} />
						</Table.Row>
					</Table>
				</Grid.Row>
				<Grid.Row only='mobile'>
					<Table celled textAlign="center">
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
					</Table>
				</Grid.Row>
			</Grid>
		</Modal.Content>
	)
})