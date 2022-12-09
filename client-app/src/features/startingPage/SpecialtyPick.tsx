import React, { useEffect } from 'react';
import { Dropdown } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

export default function SpecialtyPick() {
	const { specilatyStore } = useStore();
	const { specialties, loadSpecialties } = specilatyStore;

	useEffect(() => {
		if (specialties.length === 0) {
			loadSpecialties();
		}
	}, [specialties.length, loadSpecialties])

	return (
		<>
			{/* <Dropdown options={} clearable/> */}
		</>
	)
}