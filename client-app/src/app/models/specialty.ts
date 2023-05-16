import { Degree } from "./degree";

export interface Specialty {
	id: string;
	facultyId: string;
	universityId: string;
	specialtyBase: SpecialtyBase;
	priceUAH: number;
	description: string;
	budgetAllowed: boolean;
	ectsCredits: number;
	startYear: number;
	endYear: number;
	degree: Degree;
	languages: Language[];
	studyForms: StudyForm[];
}

export interface SpecialtyBase {
	id: string;
	name: string;
	isceds: Isced[];
}

export interface SpecialtyBaseDto {
	id: string;
	name: string;
}

export interface Isced {
	id: string;
	name: string;
}

export interface Language {
	id: string;
	name: string;
}

export interface StudyForm {
	id: number;
	form: string;
}

export class SpecialtyFormValues {
	id: string = "";
	specialtyBase?: SpecialtyBase;
	priceUAH: number = 0;
	description: string = "";
	budgetAllowed: boolean = false;
	ectsCredits: number = 0;
	degree?: Degree;
	languages?: Language[];
	studyForms?: StudyForm[];
}