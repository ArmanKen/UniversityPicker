import { createRoot } from 'react-dom/client';
import 'react-toastify/dist/ReactToastify.min.css'
import './app/layout/styles.css';
import reportWebVitals from './reportWebVitals';
import { store, StoreContext } from './app/stores/store';
import {  RouterProvider } from "react-router-dom";
import { router } from "./features/routes/Router";


const root = createRoot(document.getElementById("root") as HTMLElement);

root.render(
	<StoreContext.Provider value={store}>
		<RouterProvider router={router}/>
	</StoreContext.Provider>
);

reportWebVitals();