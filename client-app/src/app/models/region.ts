import { City } from "./city";

export interface Region {
	id: number;
	name: string;
	cities: City[];
}