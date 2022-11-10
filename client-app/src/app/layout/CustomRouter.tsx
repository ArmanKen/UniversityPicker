import React, { FC, useLayoutEffect, useState } from 'react';
import { Router, RouterProps } from 'react-router-dom';
import { BrowserHistory, MemoryHistory } from 'history';

interface CustomRouterProps extends Omit<RouterProps, 'location' | 'navigator'> {
	history: BrowserHistory;
}

export const CustomRouter: FC<CustomRouterProps> = ({ basename, children, history }) => {
	const [state, setState] = useState<Pick<MemoryHistory, 'action' | 'location'>>({
		action: history.action,
		location: history.location,
	});

	useLayoutEffect(() => history.listen(setState), [history]);

	return (
		<Router
			basename={basename}
			children={children}
			location={state.location}
			navigationType={state.action}
			navigator={history}
		/>
	);
};