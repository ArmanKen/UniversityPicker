import { City, Region } from "./region";

export interface Pagination {
	currentPage: number;
	itemsPerPage: number;
	totalItems: number;
	totalPages: number;
}

export class PaginatedResult<T> {
	data: T;
	pagination: Pagination;

	constructor(data: T, pagination: Pagination) {
		this.data = data;
		this.pagination = pagination;
	}
}

export class PagingParams {
	pageNumber;
	pageSize;

	constructor(pageNumber = 1, pageSize = 16) {
		this.pageNumber = pageNumber;
		this.pageSize = pageSize;
	}
}

export class UniversityParams {
	name = '';
	region: Region | undefined = undefined;
	city: City | undefined = undefined;
	degree = '';
	branchBaseId = '';
	specialtyBaseId = '';
	budgetAllowed = false;
	minPrice = 0;
	maxPrice = 0;
	ukraineTop = 0;
}

export class SpecialtyParams {
	searchString = '';
}