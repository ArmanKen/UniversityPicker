import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import { Button, Label } from 'semantic-ui-react';
import MyTextInput from '../../app/common/form/MyTextInput';
import { useStore } from '../../app/stores/store';

export default observer(function LoginForm() {
	const { userStore } = useStore()
	return (
		<Formik
			initialValues={{ email: '', password: '', error: null }}
			onSubmit={(values, { setErrors }) => userStore.login(values).catch(error =>
				setErrors({ error: 'Invalid Email or Password' }))}>
			{({ handleSubmit, isSubmitting, errors }) => (
				<Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
					<MyTextInput name='email' placeholder='Email' readOnly={false} />
					<MyTextInput name='password' placeholder='Password' type='password' readOnly={false} />
					<ErrorMessage
						name='error' render={() =>
							<Label style={{ marginBottom: 10 }} basic color='red' content={errors.error} />}
					/>
					<Button loading={isSubmitting} color="black" content='Login' type='submit' fluid />
				</Form>
			)}
		</Formik>
	)
})