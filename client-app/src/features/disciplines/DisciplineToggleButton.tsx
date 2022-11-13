import React, { Component } from 'react'
import { Button } from 'semantic-ui-react'
import { Discipline } from '../../app/models/discipline';


interface Props {
	discipline: Discipline,
	addToSelectedDisciplines: any,
	deleteFromSelectedDisciplines: any,
}

export default class DisciplineToggleButton extends Component<Props> {
	state = {
		active: false
	}

	render() {
		const discipline = this.props.discipline;
		const addToSelectedDisciplines = this.props.addToSelectedDisciplines;
		const deleteFromSelectedDisciplines = this.props.deleteFromSelectedDisciplines;

		const handleClick = () => {
			if (this.state.active === false) {
				addToSelectedDisciplines(discipline)
				this.setState({ active: true });
			} else {
				deleteFromSelectedDisciplines(discipline)
				this.setState({ active: false });
			}
		}

		return (
			<Button toggle color='black' active={this.state.active} onClick={handleClick} content={discipline.name} />
		)
	}
}
