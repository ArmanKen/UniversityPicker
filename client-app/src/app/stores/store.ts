import { createContext, useContext } from "react";
import BranchOfKnowledgeStore from "./branchOfKnowledgeStore";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";
import ModalStore from "./modalStore";
import SpecilatyStore from "./specialtyStore";
import StepStore from "./stepStore";
import UniversityStore from "./universityStore";

interface Store {
	universityStore: UniversityStore,
	branchOfKnowledgeStore: BranchOfKnowledgeStore,
	commonStore: CommonStore,
	specilatyStore: SpecilatyStore,
	stepStore: StepStore,
	disciplineStore: DisciplineStore,
	modalStore: ModalStore
}

export const store: Store = {
	specilatyStore: new SpecilatyStore(),
	universityStore: new UniversityStore(),
	branchOfKnowledgeStore: new BranchOfKnowledgeStore(),
	commonStore: new CommonStore(),
	stepStore: new StepStore(),
	disciplineStore: new DisciplineStore(),
	modalStore: new ModalStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}