import { Photo } from "./photo";
import { City, Region } from "./region";

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
}

export class University implements University {
	constructor(init?: UniversityFormValues) {
		Object.assign(this, init);
	}
}

export class UniversityFormValues {
	id?: string = undefined;
	name: string = '';
	region?: Region = undefined;
	city?: City = undefined;
	address: string = '';
	website: string = '';
	info: string = '';
	telephone: string = '';
	studentsCount: number = 0;
	titlePhoto?: Photo = undefined;

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
