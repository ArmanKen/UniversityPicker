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

export class UniversityParams {
	pageNumber;
	pageSize;
	name = '';
	region = '';
	city = '';
	degree = '';
	branchBaseId = '';
	specialtyBaseId = '';
	budgetAllowed = '';
	minPrice = '';
	maxPrice = '';
	ukraineTop = '';

	constructor(pageNumber = 1, pageSize = 16) {
		this.pageNumber = pageNumber;
		this.pageSize = pageSize;
	}
}

export class SpecialtyParams {
	pageNumber;
	pageSize;
	searchString = '';

	constructor(pageNumber = 1, pageSize = 20) {
		this.pageNumber = pageNumber;
		this.pageSize = pageSize;
	}
}