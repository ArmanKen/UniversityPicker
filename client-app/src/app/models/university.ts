import { Photo } from "./photo";
import { City, Region } from "./region";

export interface Institution {
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

export class Institution implements Institution {
	constructor(init?: InstitutionFormValues) {
		Object.assign(this, init);
	}
}

export class InstitutionFormValues {
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

	constructor(institution?: InstitutionFormValues) {
		if (institution) {
			this.id = institution.id;
			this.name = institution.name;
			this.region = institution.region;
			this.city = institution.city;
			this.address = institution.address;
			this.website = institution.website;
			this.info = institution.info;
			this.studentsCount = institution.studentsCount;
			this.titlePhoto = institution.titlePhoto;
		}
	}
}
