import { KnowledgeBranch } from "./knowledgeBranch";
import { Photo } from "./photo";

export interface Faculty {
	id: string;
	universityId: string;
	name: string;
	info: string;
	studentsCount: number;
	facultyPhoto: Photo;
	knowledgeBranches: KnowledgeBranch[];
}

export class FacultyFormValues {
	id: string = '';
	name: string = '';
	info: string = '';
	facultyPhoto?: Photo;
	knowledgeBranches?: KnowledgeBranch[];
}