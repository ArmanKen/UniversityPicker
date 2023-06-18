import { City, RegionDto } from "./region";

export interface HigherEducationFacility {
	id: string;
	name: string;
	accreditation: Accreditation;
	region: RegionDto;
	city: City;
	address: string;
	rating: number;
	website: string;
	info: string;
	telephone: string;
	ukraineTop: number;
	studentsCount: number;
	titlePhoto: string;
	location: Location;
	inFavoriteList: boolean;
}

export interface Accreditation {
	id: number;
	accreditationLevel: string;
}

export interface Location {
	id: number;
	longitude: number;
	latitude: number;
}

export interface HigherEducationFacilityFormValues {
	id: string;
	name: string;
	accreditation: number;
	region: number;
	city: number;
	address: string;
	website: string;
	info: string;
	telephone: string;
	ukraineTop: number;
	titlePhoto: string;
	locationLat?: number;
	locationLong?: number;
}

export interface HigherEducationFacilityQueryParams {
	name: string,
	accreditationId: number,
	regionsId: number[],
	citiesId: number[],
	degreeId: number,
	knowledgeBranchesId: string[],
	specialtyBasesId: string[],
	minPrice: number,
	maxPrice: number,
	budget: boolean,
	ukraineTop: boolean
}