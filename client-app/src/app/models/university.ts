import { Photo } from "./photo";

export interface University {
	id: string;
	name: string;
	region: string;
	city: string;
	address: string;
	rating: number;
	website: string;
	info: string;
	telephone: string;
	ukraineTop: number;
	studentsCount: number;
	priceUAH: number;
	titlePhoto: Photo;
	photos: Photo[];
}