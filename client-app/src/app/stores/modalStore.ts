import { makeAutoObservable } from "mobx"

export default class ModalStore {
	header: JSX.Element | null = null;
	body: JSX.Element | null = null;
	action: JSX.Element | null = null;
	open = false;
	size: 'mini' | 'tiny' | 'small' | 'large' | 'fullscreen' = 'small';

	constructor() {
		makeAutoObservable(this);
	}

	openModal = (header: JSX.Element, content: JSX.Element, action: JSX.Element,
		size: 'mini' | 'tiny' | 'small' | 'large' | 'fullscreen') => {
		this.open = true;
		this.header = header;
		this.body = content;
		this.action = action;
		this.size = size;
	}

	closeModal = () => {
		this.open = false;
		this.body = null;
	}
}