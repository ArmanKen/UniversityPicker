import { Degree } from "./degree";
import { Faculty } from "./faculty";
import { Photo } from "./photo";
import { SpecialtyBase } from "./specialty";
import { HigherEducationFacility } from "./higherEducationFacility";

export interface Profile {
	username: string;
	fullName: string;
	bio: string;
	specialty: string;
	higherEducationFacility: HigherEducationFacility;
	faculty: Faculty;
	specialtyBase: SpecialtyBase;
	photo: Photo;
	degree: Degree;
}

export interface CurrentStatus {
	id: number;
	status: string;
}