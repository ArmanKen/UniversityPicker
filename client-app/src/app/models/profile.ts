import { Degree } from "./degree";
import { Photo } from "./photo";
import { SpecialtyBase } from "./specialty";
import { HigherEducationFacility } from "./higherEducationFacility";

export interface Profile {
	username: string;
	fullName: string;
	bio: string;
	higherEducationFacility: HigherEducationFacility;
	currentStatus: CurrentStatus;
	specialtyBase: SpecialtyBase;
	photo: Photo;
	degree: Degree;
}

export interface CurrentStatus {
	id: number;
	status: string;
}

export interface ProfileFormValues {
	fullName: string;
	bio: string;
	currentStatus: number;
	specialtyBase: string;
	degree: number;
}

