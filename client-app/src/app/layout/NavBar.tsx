import React from 'react'
import { Label, Menu } from 'semantic-ui-react'

export default function NavBar() {
	//TODO:Icon
	return (
		<>
			<Menu fixed='top' borderless size='small'>
				<Menu.Item position='left' />
				<Menu.Item>
					<Label content='U' color='blue' circular size='massive' />
				</Menu.Item>
				<Menu.Item position='right' />
			</Menu>
		</>
	)
} 