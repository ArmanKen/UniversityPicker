import React from 'react';
import { Dropdown } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

export default function SpecialtyPick() {
	const { specialtyStore } = useStore();
	const { specialties} = specialtyStore;

	return (
		<>
			<Dropdown options={specialties} clearable/>
		</>
	)
}