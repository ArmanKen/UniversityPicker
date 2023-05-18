import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import EduComponentStore from "./eduComponentStore";
import ModalStore from "./modalStore";
import SpecilatyStore from "./specialtyStore";
import UIStore from "./uiStore";
import HigherEducationFacilityStore from "./higherEducationFacilityStore";
import FacultyStore from "./facultyStore";
import { PhotoStore } from "./photoStore";
import UserStore from "./userStore";
import ProfileStore from "./profileStore";

interface Store {
	higherEducationFacilityStore: HigherEducationFacilityStore,
	facultyStore: FacultyStore,
	specilatyStore: SpecilatyStore,
	eduComponentStore: EduComponentStore,
	commonStore: CommonStore,
	modalStore: ModalStore,
	photoStore: PhotoStore,
	userStore: UserStore,
	profileStore: ProfileStore,
	uiStore: UIStore
}

export const store: Store = {
	higherEducationFacilityStore: new HigherEducationFacilityStore(),
	facultyStore: new FacultyStore(),
	specilatyStore: new SpecilatyStore(),
	eduComponentStore: new EduComponentStore(),
	commonStore: new CommonStore(),
	modalStore: new ModalStore(),
	photoStore: new PhotoStore(),
	userStore: new UserStore(),
	profileStore: new ProfileStore(),
	uiStore: new UIStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}