import { observer } from 'mobx-react-lite'
import React from 'react'
import { Link } from 'react-router-dom'
import { Dropdown, Header, Input, Menu } from 'semantic-ui-react'
import { useStore } from '../stores/store'

export default observer(function NavBar() {
	const { institutionStore: { changeQueryParams } } = useStore()

	return (
		<Menu
			fixed='top'
			size='massive'>
			<Menu.Item
				position='left'
				style={{ marginLeft: 15 }}>
				<Header
					textAlign='center'
					as={Link} to=''>
					Institution Picker
				</Header>
			</Menu.Item>
			<Menu.Item
				position='right'
				style={{ width: 600 }}>
				<Input
					icon='search'
					placeholder='Пошук по назві університету...'
					onChange={(e, d) => changeQueryParams(d.value, "searchString")}
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