import { Discipline } from "./discipline";

export interface Specialty {
	id: string;
	name: string;
	code: number;
	disciplines: Discipline[];
}