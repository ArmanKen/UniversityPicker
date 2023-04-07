import { observer } from 'mobx-react-lite'
import React from 'react'
import { Link } from 'react-router-dom'
import { Dropdown, Header, Input, Menu } from 'semantic-ui-react'
import { useStore } from '../stores/store'
import { action } from "mobx"

export default observer(function NavBar() {
	const { universityStore: { universityQueryParams } } = useStore()

	return (
		<Menu
			fixed='top'
			size='massive'>
			<Menu.Item
				position='left'>
				<Header
					textAlign='center'
					as={Link} to=''>
					University Picker
				</Header>
			</Menu.Item>
			<Menu.Item
				position='right'
				>
				<Input
					icon='search'
					value={universityQueryParams.name}
					placeholder='Пошук по назві університету...'
					onChange={action((e, d) => universityQueryParams.name = d.value)}
				/>
			</Menu.Item>
			<Menu.Item
				position='right'>
				<Dropdown
				//account
				/>
			</Menu.Item>
		</Menu>
	)
})