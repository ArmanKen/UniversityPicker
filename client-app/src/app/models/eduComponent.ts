export interface EduComponent {
	id: string;
	name: string;
	info: string;
	isOptional: boolean;
	ectsCredits: number;
}

export class EduComponentFormValues {
	id: string = "";
	name: string = "";
	info: string = "";
	isOptional: boolean = false;
	ectsCredits: number = 0;
}