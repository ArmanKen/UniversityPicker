import { BranchOfKnowledge } from "./branchOfKnowledge";

export interface University {
	id: string;
	name: string;
	region: string;
	city: string;
	address: string;
	website: string;
	branchesOfKnowledge: BranchOfKnowledge[];
}