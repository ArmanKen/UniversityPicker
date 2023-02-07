import { Isced } from "./isced";

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