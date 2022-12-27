import { makeAutoObservable } from "mobx";
import { allBranchesOfKnowledge } from "../common/valuesForLists/allBranchesOfKnowledge";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";
import { store } from "./store";

export default class BranchOfKnowledgeStore {
	branchesOfKnowledge: BranchOfKnowledge[] = [];
	selectedBranchOfKnowledge: BranchOfKnowledge | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
		this.branchesOfKnowledge = allBranchesOfKnowledge;
	}

	updateSelectedBranchOfKnowledge = (branchOfKnowledge: BranchOfKnowledge) => {
		if (this.selectedBranchOfKnowledge !== undefined) {
			this.selectedBranchOfKnowledge.isSelected = false;
		}
		this.selectedBranchOfKnowledge = branchOfKnowledge;
		this.selectedBranchOfKnowledge.isSelected = true;
		store.specilatyStore.undoSpecialtyStore();
	}
}