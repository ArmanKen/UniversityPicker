import React from 'react';
import ReactDOM from 'react-dom/client';
import 'react-toastify/dist/ReactToastify.min.css'
import './app/layout/styles.css';
import App from './app/layout/App';
import reportWebVitals from './reportWebVitals';
import { createBrowserHistory } from 'history';
import { CustomRouter } from './app/layout/CustomRouter';
import { store, StoreContext } from './app/stores/store';

export const history = createBrowserHistory();

const root = ReactDOM.createRoot(
	document.getElementById('root') as HTMLElement
);
root.render(
	<StoreContext.Provider value={store}>
		<CustomRouter history={history}>
			<App />
		</CustomRouter>
	</StoreContext.Provider>
);

reportWebVitals();
