import { Degree } from "./degree";
import { KnowledgeBranch } from "./knowledgeBranch";
import { CurrentStatus } from "./profile";
import { Region } from "./region";
import { Language, StudyForm } from "./specialty";
import { Accreditation } from "./university";

export interface DropdownValues {
	degrees: Degree[];
	regions: Region[];
	currentStatuses: CurrentStatus[];
	knowledgeBranches: KnowledgeBranch[];
	languages: Language[];
	studyForms: StudyForm[];
	accreditations: Accreditation[];
}