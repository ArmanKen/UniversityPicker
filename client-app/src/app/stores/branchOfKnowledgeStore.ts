import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";

export default class BranchOfKnowledgeStore {
	branchesOfKnowledge: BranchOfKnowledge[] = [];
	selectedBranchOfKnowledge: BranchOfKnowledge | undefined = undefined;
	loadingInitial = false;
	branchOfKnowledgeSelectionActive = true;
	branchOfKnowledgeSelectionCompleted = false;

	constructor() {
		makeAutoObservable(this);
	}

	loadBranchesOfKnowledge = async () => {
		this.setLoadingInitial(true);
		try {
			const branchesOfKnowledge = await agent.BranchesOfKnowledge.list();
			runInAction(() => {
				branchesOfKnowledge.forEach(branchOfKnowledge => {
					this.branchesOfKnowledge.push(branchOfKnowledge);
				})
			})
			this.setLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.setLoadingInitial(false);
		}
	}

	setLoadingInitial = (state: boolean) => {
		this.loadingInitial = state;
	}

	updateSelectedBranchOfKnowledge = (branchOfKnowledge: BranchOfKnowledge) => {
		if (this.selectedBranchOfKnowledge !== undefined) {
			this.selectedBranchOfKnowledge.isSelected = false;
		}
		this.selectedBranchOfKnowledge = branchOfKnowledge;
		this.selectedBranchOfKnowledge.isSelected = true;
	}

	activateBranchOfKnowledgeSelection = () => {
		this.branchOfKnowledgeSelectionActive = true;
		this.branchOfKnowledgeSelectionCompleted = false;
	}

	completeBranchOfKnowledgeSelection = () => {
		
		this.branchOfKnowledgeSelectionActive = false;
		this.branchOfKnowledgeSelectionCompleted = true;
	}
}