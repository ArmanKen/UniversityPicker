import { observer } from 'mobx-react-lite';
import React from 'react';
import { Modal, Transition } from 'semantic-ui-react';
import { useStore } from '../../stores/store';

export default observer(function ModalContainer() {
	const { modalStore: { size, open, body, closeModal, header, action } } = useStore();

	return (
		<Transition.Group animation='fade'
			duration={300} open={open}	>
			{open && <Modal closeIcon open={open} closeOnDimmerClick
				closeOnEscape onClose={closeModal} size={size} >
				{header}
				{body}
				{action}
			</Modal >}
		</Transition.Group >
	)
})