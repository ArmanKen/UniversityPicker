import { makeAutoObservable, runInAction } from "mobx";
import { Faculty, FacultyFormValues } from "../models/faculty";
import agent from "../api/agent";

export default class FacultyStore {
	faculties = new Map<string, Faculty>();
	selectedFaculty: Faculty | undefined = undefined;
	facultyLoadingInitial = true;

	constructor() {
		makeAutoObservable(this);
	}

	setFacultyLoadingInitial = (state: boolean) => this.facultyLoadingInitial = state;

	setFaculty = (faculty: Faculty) => this.selectedFaculty = faculty;

	clearFaculty = () => this.selectedFaculty = undefined;

	private getFaculty = (facultyId: string) => this.faculties.get(facultyId);

	loadFaculties = async (higherEducationFacilityId: string) => {
		this.setFacultyLoadingInitial(true);
		try {
			const result = await agent.Faculties.list(higherEducationFacilityId);
			runInAction(() => {
				result.forEach(faculty => {
					this.faculties.set(faculty.id, faculty);
				});
			});
			this.setFacultyLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setFacultyLoadingInitial(false);
		}
	}

	loadFaculty = async (facultyId: string) => {
		this.setFacultyLoadingInitial(true);
		try {
			const faculty = await agent.Faculties.details(facultyId);
			this.setFaculty(faculty);
			this.setFacultyLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setFacultyLoadingInitial(false);
		}
	}

	createFaculty = async (facultyId: string, faculty: FacultyFormValues) => {
		this.setFacultyLoadingInitial(true);
		try {
			await agent.Faculties.create(facultyId, faculty);
			this.setFacultyLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setFacultyLoadingInitial(false);
		}
	}

	editFaculty = async (higherEducationFacilityId: string, faculty: FacultyFormValues) => {
		this.setFacultyLoadingInitial(true);
		try {
			await agent.Faculties.edit(higherEducationFacilityId, faculty);
			this.setFacultyLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setFacultyLoadingInitial(false);
		}
	}

	deleteFaculty = async (higherEducationFacilityId: string, facultyId: string) => {
		this.setFacultyLoadingInitial(true);
		try {
			await agent.Faculties.delete(higherEducationFacilityId, facultyId);
			this.faculties.delete(facultyId);
			this.setFacultyLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setFacultyLoadingInitial(false);
		}
	}
}