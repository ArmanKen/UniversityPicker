import { createContext, useContext } from "react";
import BranchOfKnowledgeStore from "./branchOfKnowledgeStore";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";

interface Store {
	disciplineStore: DisciplineStore,
	branchOfKnowledgeStore:BranchOfKnowledgeStore,
	commonStore: CommonStore
}

export const store: Store = {
	disciplineStore: new DisciplineStore(),
	branchOfKnowledgeStore: new BranchOfKnowledgeStore(),
	commonStore: new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}