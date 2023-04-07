export interface Region {
	id: number;
	name: string;
	cities: City[];
}

export interface RegionDto {
	id: number;
	name: string;
}

export interface City {
	id: number;
	name: string;
}