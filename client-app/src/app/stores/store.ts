import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import DisciplineStore from "./disciplineStore";

interface Store {
	disciplineStore: DisciplineStore,
	commonStore: CommonStore
}

export const store: Store = {
	disciplineStore: new DisciplineStore(),
	commonStore: new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore() {
	return useContext(StoreContext);
}