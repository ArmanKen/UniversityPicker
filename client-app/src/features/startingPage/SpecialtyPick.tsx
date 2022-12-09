import React, { useEffect } from 'react';
import { Dropdown } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';

export default function SpecialtyPick() {
	const { specilatyStore } = useStore();
	const { specialties, loadSpecialties, dropdownContent,loadDropdownContent } = specilatyStore;

	useEffect(() => {
		if (specialties.length === 0) {
			loadSpecialties();
			loadDropdownContent()
		}
	}, [specialties.length, loadSpecialties,loadDropdownContent])

	return (
		<>
			<Dropdown options={dropdownContent} clearable selection fluid/>
		</>
	)
}