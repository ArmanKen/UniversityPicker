import { action } from "mobx"
import { observer } from 'mobx-react-lite'
import { Link, useLocation } from 'react-router-dom'
import { Dropdown, Header, Input, Menu } from 'semantic-ui-react'
import { useStore } from '../stores/store'

export default observer(function NavBar() {
	const { universityStore: { universityQueryParams } } = useStore()
	const location = useLocation();

	return (
		<Menu
			style={{ zIndex: 900 }}
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
			{location.pathname === '/' && <Menu.Item>
				<Input
					style={{ width: '30vw' }}
					icon='search'
					value={universityQueryParams.name}
					placeholder='Пошук...'
					onChange={action((e, d) => universityQueryParams.name = d.value)}
				/>
			</Menu.Item>}
			<Menu.Item
				position='right'>
				<Dropdown
				//account
				/>
			</Menu.Item>
		</Menu>

	)
})