export interface Specialty {
	id: string;
	specialtyBaseId: string;
	name: string;
	isceds: Isced[];
	priceUAH: number;
	description: string;
	budgetAllowed: boolean;
	ectsCredits: number; 
	startYear: number;
	endYear: number;
	degree: string;
}

export interface SpecialtyBase {
	id: string;
	name: string;
	isceds: Isced[];
}

export interface Isced {
	id: string;
	name: string;
}