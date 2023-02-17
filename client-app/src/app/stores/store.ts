import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";
import ModalStore from "./modalStore";
import SpecilatyStore from "./specialtyStore";
import StepStore from "./stepStore";
import UniversityStore from "./universityStore";

interface Store {
	universityStore: UniversityStore,
	commonStore: CommonStore,
	specilatyStore: SpecilatyStore,
	stepStore: StepStore,
	disciplineStore: DisciplineStore,
	modalStore: ModalStore,
}

export const store: Store = {
	specilatyStore: new SpecilatyStore(),
	universityStore: new UniversityStore(),
	commonStore: new CommonStore(),
	stepStore: new StepStore(),
	disciplineStore: new DisciplineStore(),
	modalStore: new ModalStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}