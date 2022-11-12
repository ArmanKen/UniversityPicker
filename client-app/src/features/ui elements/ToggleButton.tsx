import React, { Component } from 'react'
import { Button } from 'semantic-ui-react'


interface Props {
	content: string
}

export default class ToggleButton extends Component<Props> {
	state = {
		active: false
	};

	handleClick = () => {
		this.state.active === true ?
			this.setState({ active: false })
			: this.setState({ active: true });
	}

	render() {
		const { active } = this.state;
		const { content } = this.props;
		return (
			<Button toggle color='black' active={active} onClick={this.handleClick} content={content} />
		)
	}
}
