import React from 'react'
import { Label, Menu } from 'semantic-ui-react'

export default function NavBar() {
	return (
		<Menu fixed='top' borderless inverted size='small' color="blue">
			<Menu.Item position='left' />
			<Menu.Item>
				<Label content='U' color='yellow' circular size='massive' />
			</Menu.Item>
			<Menu.Item position='right' />
		</Menu>
	)
} 