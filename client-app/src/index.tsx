import { createRoot } from 'react-dom/client';
import 'react-toastify/dist/ReactToastify.min.css'
import './app/layout/styles.css';
import reportWebVitals from './reportWebVitals';
import { store, StoreContext } from './app/stores/store';
import App from "./app/layout/App";
import { BrowserRouter } from "react-router-dom";


const root = createRoot(document.getElementById("root") as HTMLElement);

root.render(
	<StoreContext.Provider value={store}>
		<BrowserRouter>
			<App />
		</BrowserRouter>
	</StoreContext.Provider>
);

reportWebVitals();
