import { observer } from "mobx-react-lite";
import React from "react";
import { Card, Icon, Image, Modal, Transition } from "semantic-ui-react";
import { Institution } from "../../../app/models/institution";
import { useStore } from "../../../app/stores/store";
import InstitutionModalActions from "../../modals/institutionModal/InstitutionModalActions";
import InstitutionModalBody from "../../modals/institutionModal/InstitutionModalBody";

interface Props {
	institution: Institution
}

export default observer(function InstitutionListCard({ institution }: Props) {
	const { institutionStore: { setInstitution }, modalStore: { openModal } } = useStore();

	return (
		<Transition animation="fade" duration={300}
			unmountOnHide={true} transitionOnMount={true}>
			<Card raised style={{ width: 250, height: 250 }}
				onClick={() => {
					setInstitution(institution);
					openModal(<Modal.Header content='Про університет' />,
						<InstitutionModalBody />, <InstitutionModalActions />, 'small');
				}}>
				<div style={{ position: "relative", display: "flex" }}>
					<Image fluid style={{ width: 250, height: 150 }} src='assets/1.png' />
					<div className="square" style={{ position: 'absolute', bottom: 0 }}>
						<Icon name='star' size='large'
							style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
							{institution.rating.toFixed(1)}
						</Icon>
					</div>
				</div>
				<Card.Content textAlign="center" style={{ fontSize: '0.9em', fontWeight: 600, height: 150 }}>
					<Card.Header content={institution.name} />
				</Card.Content>
			</Card>
		</Transition>
	)
})