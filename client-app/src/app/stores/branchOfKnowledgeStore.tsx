import { makeAutoObservable } from "mobx";
import { AccordionPanelProps, Checkbox, DropdownItemProps, Label, Menu } from "semantic-ui-react";
import { allBranchesOfKnowledge } from "../common/valuesForLists/allBranchesOfKnowledge";
import { BranchOfKnowledge } from "../models/branchOfKnowledge";
import { store } from "./store";

export default class BranchOfKnowledgeStore {
	branchesOfKnowledge: BranchOfKnowledge[] = [];
	selectedBranchOfKnowledge: BranchOfKnowledge | undefined = undefined;
	dropdownContent: DropdownItemProps[] = [];

	constructor() {
		makeAutoObservable(this);
		this.branchesOfKnowledge = allBranchesOfKnowledge;
		this.branchesOfKnowledge.forEach(branchOfKnowledge => {
			this.dropdownContent.push({ key: branchOfKnowledge.code, text: branchOfKnowledge.name, value: branchOfKnowledge.code });
		})
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