import { createContext, useContext } from "react";
import BranchOfKnowledgeStore from "./branchOfKnowledgeStore";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";
import SpecialtieStore from "./specialtieStore";

interface Store {
	disciplineStore: DisciplineStore,
	branchOfKnowledgeStore: BranchOfKnowledgeStore,
	specialtieStore: SpecialtieStore,
	commonStore: CommonStore
}

export const store: Store = {
	disciplineStore: new DisciplineStore(),
	branchOfKnowledgeStore: new BranchOfKnowledgeStore(),
	specialtieStore: new SpecialtieStore(),
	commonStore: new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}