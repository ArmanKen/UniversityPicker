export interface Review {
	id: string;
	createdAt: Date;
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