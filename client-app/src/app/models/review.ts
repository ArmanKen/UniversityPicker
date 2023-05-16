export interface Review {
	id: string;
	createAt: any;
	rating: number;
	body: string;
	username: string;
	fullName: string;
	image: string;
}

export class ReviewFormValues {
	id: string = "";
	rating: number = 0;
	body: string = "";
}