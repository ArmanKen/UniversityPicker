import { makeAutoObservable } from "mobx";

export default class SidebarStore {
	filterSidebarOpen = false;
	universitySidebarOpen = false;

	constructor() {
		makeAutoObservable(this);
	}

	setFilterSidebarOpen = (state: boolean) => {
		this.filterSidebarOpen = state;
	}

	setUniversitySidebarOpen = (state: boolean) => {
		this.universitySidebarOpen = state;
	}
}