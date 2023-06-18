import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Specialty } from "../models/specialty";

export default class SpecilatyStore {
	junBachelorSpecialties = new Map<string, Specialty>();
	bachelorSpecialties = new Map<string, Specialty>();
	magisterSpecialties = new Map<string, Specialty>();
	specialtyLoadingInitial = false;
	selectedSpecialty: Specialty | undefined = undefined;

	constructor() {
		makeAutoObservable(this);
	}

	setSpecialty = (specialty: Specialty) => this.selectedSpecialty = specialty;

	setSpecialtyLoadingInitial = (state: boolean) => this.specialtyLoadingInitial = state;

	clearSpecialties = () => {
		this.junBachelorSpecialties.clear();
		this.bachelorSpecialties.clear();
		this.magisterSpecialties.clear();
	}

	loadSpecialties = async (facultyId: string) => {
		this.setSpecialtyLoadingInitial(true);
		try {
			const result = await agent.Specialties.list(facultyId);
			runInAction(() => {
				result.forEach(specialty => {
					if (specialty.degree)
						specialty.degree.name === "Молодший Бакалавр" ?
							this.junBachelorSpecialties.set(specialty.id, specialty) :
							specialty.degree.name === "Магістр" ?
								this.magisterSpecialties.set(specialty.id, specialty) :
								this.bachelorSpecialties.set(specialty.id, specialty);
					else
						this.bachelorSpecialties.set(specialty.id, specialty);
				});
			});
			this.setSpecialtyLoadingInitial(false);
		} catch (error) {
			console.log(error);
			this.setSpecialtyLoadingInitial(false);
		}
	}

	loadSpecialty = async (specialtyId: string) => {
		this.setSpecialtyLoadingInitial(true);
		try {
			const specialty = await agent.Specialties.details(specialtyId);
			this.setSpecialty(specialty);
			this.setSpecialtyLoadingInitial(false);
		} catch (error) {
			runInAction(() => {
				console.log(error);
			});
			this.setSpecialtyLoadingInitial(false);
		}
	}
}