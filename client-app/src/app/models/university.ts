import { Specialty } from "./specialty";

export interface University {
	id: string;
	name: string;
	shortInfo: string;
	fullInfo: string;
	region: string;
	address: string;
	website: string;
	rating: number;
	countryTopRating: number;
	telephone: string;
	specialties: Specialty[];
}