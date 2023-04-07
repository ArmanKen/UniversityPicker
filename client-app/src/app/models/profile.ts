import { Degree } from "./degree";
import { Faculty } from "./faculty";
import { Photo } from "./photo";
import { SpecialtyBase } from "./specialty";
import { University } from "./university";

export interface Profile {
	username: string;
	fullName: string;
	bio: string;
	specialty: string;
	university: University;
	faculty: Faculty;
	specialtyBase: SpecialtyBase;
	photo: Photo;
	degree: Degree;
}

export interface CurrentStatus {
	id: number;
	status: string;
}