import { City, RegionDto } from "./region";

export interface University {
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

export class University implements University {
	constructor(init?: UniversityFormValues) {
		Object.assign(this, init);
	}
}

export class UniversityFormValues {
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

	constructor(university?: UniversityFormValues) {
		if (university) {
			this.id = university.id;
			this.name = university.name;
			this.region = university.region;
			this.city = university.city;
			this.address = university.address;
			this.website = university.website;
			this.info = university.info;
			this.studentsCount = university.studentsCount;
			this.titlePhoto = university.titlePhoto;
		}
	}
}

export interface UniversityQueryParams {
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