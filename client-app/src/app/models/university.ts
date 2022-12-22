import { string } from "yup";
import { Specialty } from "./specialty";

export interface University {
	id: string;
	name: string;
	shortName: string;
	info: string;
	region: string;
	city: string;
	address: string;
	website: string;
	specialties: Specialty[];
}