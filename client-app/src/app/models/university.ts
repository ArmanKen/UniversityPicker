import { Specialty } from "./specialty";

export interface University {
	id: string;
	name: string;
	shortInfo: string;
	fullInfo: string;
	region: string;
	city: string;
	address: string;
	website: string;
	rating: number;
	telephone: string;
	specialties: Specialty[];
}