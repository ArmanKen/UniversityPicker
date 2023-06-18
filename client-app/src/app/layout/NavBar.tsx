import { action } from "mobx"
import { observer } from 'mobx-react-lite'
import { Link, useLocation } from 'react-router-dom'
import { Button, Dropdown, Header, Input, Menu, Image, Icon } from 'semantic-ui-react'
import { useStore } from '../stores/store'
import LoginForm from "../../features/users/LoginForm"
import RegisterForm from "../../features/users/RegisterForm"

export default observer(function NavBar() {
	const { higherEducationFacilityStore: { higherEducationFacilityQueryParams },
		userStore: { user, logout }, profileStore: { setActiveTab }, modalStore: { openModal } } = useStore()
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
					HigherEducationFacility Picker
				</Header>
			</Menu.Item>
			{location.pathname === '/' && <Menu.Item>
				<Input
					style={{ width: '30vw' }}
					icon='search'
					value={higherEducationFacilityQueryParams.name}
					placeholder='Пошук...'
					onChange={action((e, d) => higherEducationFacilityQueryParams.name = d.value)}
				/>
			</Menu.Item>}
			<Menu.Item
				position='right'>
				{user ?
					<>
						<Button icon basic inverted color='grey'
							as={Link} to={`/profile/${user.username}`}
							onClick={x => setActiveTab(1)}
						>
							<Icon name='bookmark' color='red' />
						</Button>
						<Image
							src={user.image || "../assets/149071.png"}
							style={{ marginTop: 0, marginBottom: 0, marginRight: 10,maxWidth: 50,maxHeight: 50 }}
							circular  floated="right"
						/>
						<Dropdown
							fluid
							text={user.fullName}
						>
							<Dropdown.Menu>
								<Dropdown.Item text="Профіль" as={Link} to={`/profile/${user.username}`} onClick={x => setActiveTab(0)} />
								<Dropdown.Item text="Вийти" onClick={x => logout()} />
							</Dropdown.Menu>
						</Dropdown>
					</> : <>
						<Button color="black" size="medium" style={{ marginRight: 20 }}
							onClick={x => openModal(<>Login</>, <LoginForm />, "tiny")}>
							Увійти
						</Button>
						<Button color="black" size="medium"
							onClick={x => openModal(<>Sign up</>, <RegisterForm />, "tiny")}>
							Зареєструватися
						</Button>
					</>
				}
			</Menu.Item>
		</Menu>
	)
})