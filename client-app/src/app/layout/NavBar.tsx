import React from 'react'
import { Label, Menu } from 'semantic-ui-react'

export default function NavBar() {
	return (
		<Menu fixed='top' borderless size='small' inverted className='top-menu-color'>
			<Menu.Item position='left' />
			<Menu.Item>
				<Label content='U' className='label-color' circular size='massive' />
			</Menu.Item>
			<Menu.Item position='right' />
		</Menu>
	)
} 