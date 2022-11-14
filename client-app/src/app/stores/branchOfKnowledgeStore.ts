import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";

export default class BranchOfKnowledgeStore {
	branchesOfKnowledge: BranchOfKnowledge[] = [];
	selectedBranchOfKnowledge: BranchOfKnowledge | undefined = undefined;
	loading = false;
	loadingInitial = false;

	constructor() {
		makeAutoObservable(this);
	}

	loadBranchesOfKnowledge = async () => {
		this.loadingInitial = true;
		try {
			const branchesOfKnowledge = await agent.BranchesOfKnowledge.list();
			runInAction(() => {
				branchesOfKnowledge.forEach(branchOfKnowledge => {
					this.branchesOfKnowledge.push(branchOfKnowledge);
				})
			})
			this.loadingInitial = false;
		} catch (error) {
			runInAction(() => {
				console.log(error);
			})
			this.loadingInitial = false;
		}
	}
}