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

export class HigherEducationFacility implements HigherEducationFacility {
	constructor(init?: HigherEducationFacilityFormValues) {
		Object.assign(this, init);
	}
}

export class HigherEducationFacilityFormValues {
	id: string = '';
	name: string = '';
	accreditation?: Accreditation;
	region?: RegionDto;
	city?: City;
	address: string = '';
	rating: number = 0;
	website: string = '';
	info: string = '';
	telephone: string = '';
	ukraineTop: number = 0;
	studentsCount: number = 0;
	titlePhoto: string = '';
	location?: Location;

	constructor(higherEducationFacility?: HigherEducationFacilityFormValues) {
		if (higherEducationFacility) {
			this.id = higherEducationFacility.id;
			this.name = higherEducationFacility.name;
			this.region = higherEducationFacility.region;
			this.city = higherEducationFacility.city;
			this.address = higherEducationFacility.address;
			this.website = higherEducationFacility.website;
			this.info = higherEducationFacility.info;
			this.studentsCount = higherEducationFacility.studentsCount;
			this.titlePhoto = higherEducationFacility.titlePhoto;
		}
	}
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