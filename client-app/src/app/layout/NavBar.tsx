import { observer } from 'mobx-react-lite'
import React from 'react'
import { Header, Input, Menu } from 'semantic-ui-react'
import { useStore } from '../stores/store'

export default observer(function NavBar() {
	const { universityStore: { universityLoadingInitial, changeQueryParams } } = useStore()

	return (
		<Menu
			fixed='top'
			size='massive'
			stackable>
			<Menu.Item position='left' style={{ marginLeft: 15 }}>
				<Header textAlign='center'>
					University Picker
				</Header>
			</Menu.Item>
			<Menu.Item position='right' style={{ width: 600 }}>
				<Input
					icon='search'
					placeholder='Пошук по назві університету...'
					disabled={universityLoadingInitial}
					loading={universityLoadingInitial}
					onChange={(e, d) => changeQueryParams(d.value, "searchString")}
				/>
			</Menu.Item>
		</Menu>
	)
})