import { Discipline } from "./discipline";

export interface Specialty {
	id: string;
	name: string;
	code: number;
	price: string;
	info: string;
	disciplines: Discipline[];
}