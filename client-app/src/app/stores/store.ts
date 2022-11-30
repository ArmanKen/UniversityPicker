import { createContext, useContext } from "react";
import BranchOfKnowledgeStore from "./branchOfKnowledgeStore";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";
import SpecialtyStore from "./specialtieStore";
import StepStore from "./stepStore";

interface Store {
	disciplineStore: DisciplineStore,
	branchOfKnowledgeStore: BranchOfKnowledgeStore,
	specialtyStore: SpecialtyStore,
	commonStore: CommonStore,
	stepStore: StepStore
}

export const store: Store = {
	disciplineStore: new DisciplineStore(),
	branchOfKnowledgeStore: new BranchOfKnowledgeStore(),
	specialtyStore: new SpecialtyStore(),
	commonStore: new CommonStore(),
	stepStore: new StepStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}