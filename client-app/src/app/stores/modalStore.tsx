import { makeAutoObservable } from "mobx"

export default class ModalStore {
	header: JSX.Element = <></>;
	body: JSX.Element = <></>;
	action: JSX.Element = <></>;
	open = false;
	size: 'mini' | 'tiny' | 'small' | 'large' | 'fullscreen' = 'small';

	constructor() {
		makeAutoObservable(this);
	}

	openModal = (header: JSX.Element, content: JSX.Element,
		size: 'mini' | 'tiny' | 'small' | 'large' | 'fullscreen',
		action: JSX.Element = <></> ) => {
		this.open = true;
		this.header = header;
		this.body = content;
		this.action = action;
		this.size = size;
	}

	closeModal = () => {
		this.open = false;
		this.header = <></>;
		this.body = <></>;
		this.action = <></>;
	}
}