import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";
import ModalStore from "./modalStore";
import SpecilatyStore from "./specialtyStore";
import MenuStore from "./menuStore";
import UniversityStore from "./universityStore";

interface Store {
	universityStore: UniversityStore,
	commonStore: CommonStore,
	specilatyStore: SpecilatyStore,
	disciplineStore: DisciplineStore,
	modalStore: ModalStore,
	menuStore: MenuStore
}

export const store: Store = {
	specilatyStore: new SpecilatyStore(),
	universityStore: new UniversityStore(),
	commonStore: new CommonStore(),
	disciplineStore: new DisciplineStore(),
	modalStore: new ModalStore(),
	menuStore: new MenuStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}