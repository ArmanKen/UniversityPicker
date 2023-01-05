import { makeAutoObservable } from "mobx";
import { BranchesOfKnowledge } from "../common/valuesForLists/BranchesOfKnowledge";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";
import { store } from "./store";

export default class BranchOfKnowledgeStore {
	branchesOfKnowledge: BranchOfKnowledge[] = [];
	selectedBranchOfKnowledge: BranchOfKnowledge | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
		this.branchesOfKnowledge = BranchesOfKnowledge;
	}

	updateSelectedBranchOfKnowledge = (branchOfKnowledge: BranchOfKnowledge) => {
		if (this.selectedBranchOfKnowledge) {
			this.selectedBranchOfKnowledge.isSelected = false;
		}
		this.selectedBranchOfKnowledge = branchOfKnowledge;
		this.selectedBranchOfKnowledge.isSelected = true;
		store.specilatyStore.undoSpecialtyStore();
		store.specilatyStore.updateSelectedSpecialties();
	}
}