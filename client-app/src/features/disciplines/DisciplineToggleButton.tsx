import { observer } from 'mobx-react-lite';
import React, { useState } from 'react'
import { Button } from 'semantic-ui-react'
import { Discipline } from '../../app/models/discipline';
import { useStore } from '../../app/stores/store';

interface Props {
	discipline: Discipline
}

export default observer(function DisciplineToggleButton({ discipline }: Props) {
	const { disciplineStore } = useStore()
	const { addToSelectedDisciplines, deleteFromSelectedDisciplines } = disciplineStore;
	const [active, setActive] = useState(false);

	const handleClick = () => {
		if (active === false) {
			addToSelectedDisciplines(discipline)
			setActive(!active);
		} else {
			deleteFromSelectedDisciplines(discipline)
			setActive(!active);
		}
	}

	return (
		<Button color='black' toggle active={active} onClick={handleClick} content={discipline.name} />
	)

})
