import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import EduComponentStore from "./eduComponentStore";
import ModalStore from "./modalStore";
import SpecilatyStore from "./specialtyStore";
import UIStore from "./uiStore";
import UniversityStore from "./universityStore";

interface Store {
	universityStore: UniversityStore,
	commonStore: CommonStore,
	specilatyStore: SpecilatyStore,
	eduComponentStore: EduComponentStore,
	modalStore: ModalStore,
	uiStore: UIStore
}

export const store: Store = {
	specilatyStore: new SpecilatyStore(),
	universityStore: new UniversityStore(),
	commonStore: new CommonStore(),
	eduComponentStore: new EduComponentStore(),
	modalStore: new ModalStore(),
	uiStore: new UIStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}