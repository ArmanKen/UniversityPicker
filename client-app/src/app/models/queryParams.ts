export interface UniversityParams {
	name: string,
	regions: number[],
	cities: number[],
	degree: number,
	branchBaseIds: string[],
	specialtyBaseIds: string[],
	onlyBudget: boolean,
	minPrice: number,
	maxPrice: number,
	ukraineTop: boolean
}