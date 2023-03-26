import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Icon, Image, Modal, Transition } from "semantic-ui-react";
import { University } from "../../../app/models/university";
import { useStore } from "../../../app/stores/store";
import UniversityModalActions from "../../modals/universityModal/UniversityModalActions";
import UniversityModalBody from "../../modals/universityModal/UniversityModalBody";

interface Props {
	university: University
}

export default observer(function UniversityListCard({ university }: Props) {
	const { universityStore: { setUniversity }, modalStore: { openModal } } = useStore();

	return (
		<Transition animation="fade" duration={300}
			unmountOnHide={true} transitionOnMount={true}>
			<Card raised style={{ width: 250, height: 250 }}
				onClick={() => {
					setUniversity(university);
					openModal(<Modal.Header content='Про університет' />,
						<UniversityModalBody />, <UniversityModalActions />, 'small');
				}}>
				<div style={{ position: "relative", display: "flex" }}>
					<Image fluid style={{ width: 250, height: 150 }} src='assets/1.png' />
					<div className="square" style={{ position: 'absolute', bottom: 0 }}>
						<Icon name='star' size='large'
							style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
							{university.rating.toFixed(1)}
						</Icon>
					</div>
				</div>
				<Card.Content textAlign="center" style={{ fontSize: '0.9em', fontWeight: 600, height: 150 }}>
					<Card.Header content={university.name} />
				</Card.Content>
			</Card>
		</Transition>
	)
})