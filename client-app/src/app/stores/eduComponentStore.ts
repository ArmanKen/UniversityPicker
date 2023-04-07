import { makeAutoObservable } from "mobx";
import { EduComponent } from "../models/eduComponent";

export default class EduComponentStore {
	eduComponents: EduComponent[] = [];

	constructor() {
		makeAutoObservable(this);
	}

	// loadEduComponents = () => {
	// 	try {
	// 		let selectedSpecialty = store.specilatyStore.selectedSpecialty;
	// 		if (selectedSpecialty !== undefined) {
	// 			store.universityStore.universities.forEach(university => {
	// 				let eduComponents = university.specialties.find(x => x.code === selectedSpecialty!.code)?.eduComponents!;
	// 				eduComponents.forEach(newEduComponent => {
	// 					if (!this.eduComponents.some(eduComponent => eduComponent.id === newEduComponent.id))
	// 						this.eduComponents.push(newEduComponent);
	// 				});
	// 			})
	// 		}
	// 		else {
	// 			store.specilatyStore.selectedSpecialties.forEach(specialty => {
	// 				specialty.eduComponents!.forEach(eduComponent => {
	// 					if (!this.eduComponents.some(x => x.id === eduComponent.id)) {
	// 						this.eduComponents.push(eduComponent);
	// 					}
	// 				})
	// 			})
	// 		}
	// 	} catch (error) {
	// 		console.log(error);
	// 	}
	// }

	// updateSelectedEduComponents = (eduComponent: EduComponent) => eduComponent.isSelected ?
	// 	eduComponent.isSelected = false : eduComponent.isSelected = true;

	// clearSelectedEduComponents = () => this.eduComponents.forEach(eduComponent => eduComponent.isSelected = false)

	// selectAllEduComponents = () => this.eduComponents.forEach(eduComponent => eduComponent.isSelected = true)

	// undoEduComponentStore = () => {
	// 	this.clearSelectedEduComponents();
	// 	this.eduComponents = [];
	// }
}