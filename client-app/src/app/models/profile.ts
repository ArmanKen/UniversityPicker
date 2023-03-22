import { Photo } from "./photo";
import { Institution } from "./institution";

export interface Profile {
	username: string;
	displayName: string;
	bio: string;
	specialty: string;
	institution: Institution;
	photo: Photo;
	degree: string;
}