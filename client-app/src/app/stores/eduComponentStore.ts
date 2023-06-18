import { makeAutoObservable, runInAction } from "mobx";
import { EduComponent } from "../models/eduComponent";
import agent from "../api/agent";

export default class EduComponentStore {
	eduComponents = new Map<string, EduComponent>();
	eduComponentsLoadingInitial = false;
	selectedEduComponent: EduComponent | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
	}

	setEduComponent = (eduComponents: EduComponent) => this.selectedEduComponent = eduComponents;

	seteduComponentsLoadingInitial = (state: boolean) => this.eduComponentsLoadingInitial = state;

	clearEduComponents = () => this.eduComponents.clear();

	loadEduComponents = async (specialtyId: string) => {
		this.seteduComponentsLoadingInitial(true);
		try {
			const result = await agent.EduComponents.list(specialtyId);
			runInAction(() => {
				result.forEach(eduComponent => {
					this.eduComponents.set(eduComponent.id, eduComponent);
				});
			});
			this.seteduComponentsLoadingInitial(false);
		} catch (error) {
			console.log(error);
			this.seteduComponentsLoadingInitial(false);
		}
	}
}