import { SpecialtyBase } from "./specialty";

export interface KnowledgeBranch {
	id: string;
	name: string;
	specialtyBases: SpecialtyBase[];
}