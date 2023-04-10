import { observer } from 'mobx-react-lite';
import { Modal, Transition } from 'semantic-ui-react';
import { useStore } from '../../stores/store';

export default observer(function ModalContainer() {
	const { modalStore: { size, open, body,
		closeModal, header, action } } = useStore();

	return (
		<Transition.Group animation='fade'
			duration={300}>
			{open && <Modal closeIcon open={open} closeOnDimmerClick
				closeOnEscape onClose={closeModal} size={size}>
				<Modal.Header>
					{header}
				</Modal.Header>
				<Modal.Content>
					{body}
				</Modal.Content>
				<Modal.Content>
					{action}
				</Modal.Content>
			</Modal >}
		</Transition.Group >
	)
})