import React from 'react';
import { Dropdown } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

export default function SpecialtiePick() {
	const { specialtieStore } = useStore();
	const { } = specialtieStore;
	
	return (
		<>
			<Dropdown/>
		</>
	)
}