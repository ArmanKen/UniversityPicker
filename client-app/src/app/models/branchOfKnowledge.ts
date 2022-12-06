import { Specialty } from "./specialty";

export interface BranchOfKnowledge {
	id: string;
	name: string;
	specialties: Specialty[];
}