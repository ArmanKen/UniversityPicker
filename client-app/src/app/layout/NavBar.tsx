import React from 'react'
import { Label, Menu } from 'semantic-ui-react'

export default function NavBar() {
	return (
		<Menu fixed='top' borderless size='massive' inverted className='top-menu-color'>
			<Menu.Item position='left' />
			<Menu.Item position='right' />
		</Menu>
	)
} 