import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";
import ModalStore from "./modalStore";
import SpecilatyStore from "./specialtyStore";
import MenuStore from "./menuStore";
import InstitutionStore from "./institutionStore";

interface Store {
	institutionStore: InstitutionStore,
	commonStore: CommonStore,
	specilatyStore: SpecilatyStore,
	disciplineStore: DisciplineStore,
	modalStore: ModalStore,
	menuStore: MenuStore
}

export const store: Store = {
	specilatyStore: new SpecilatyStore(),
	institutionStore: new InstitutionStore(),
	commonStore: new CommonStore(),
	disciplineStore: new DisciplineStore(),
	modalStore: new ModalStore(),
	menuStore: new MenuStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}