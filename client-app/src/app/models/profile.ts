import { Photo } from "./photo";
import { University } from "./university";

export interface Profile{
	username: string;
	displayName: string;
	bio: string;
	specialty: string;
	university: University;
	photo: Photo;
	degree: string;
}