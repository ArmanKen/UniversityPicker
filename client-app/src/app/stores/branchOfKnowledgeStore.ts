import { makeAutoObservable } from "mobx";
import { branchesOfKnowledge } from "../common/branchesOfKnowledge";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";

export default class BranchOfKnowledgeStore {
	branchesOfKnowledge: BranchOfKnowledge[] = [];
	selectedBranchOfKnowledge: BranchOfKnowledge | undefined = undefined;
	loadingInitial = false;

	constructor() {
		makeAutoObservable(this);
		this.branchesOfKnowledge = branchesOfKnowledge;
	}

	updateSelectedBranchOfKnowledge = (branchOfKnowledge: BranchOfKnowledge) => {
		if (this.selectedBranchOfKnowledge !== undefined) {
			this.selectedBranchOfKnowledge.isSelected = false;
		}
		this.selectedBranchOfKnowledge = branchOfKnowledge;
		this.selectedBranchOfKnowledge.isSelected = true;
	}
}