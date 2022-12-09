import { Specialty } from "./specialty";

export interface University {
	id: string;
	name: string;
	region: string;
	city: string;
	address: string;
	website: string;
	specialties: Specialty[];
}