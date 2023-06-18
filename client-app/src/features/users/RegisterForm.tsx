import { ErrorMessage, Form, Formik } from 'formik';
import { observer } from 'mobx-react-lite';
import { Button } from 'semantic-ui-react';
import MyTextInput from '../../app/common/form/MyTextInput';
import { useStore } from '../../app/stores/store';
import * as Yup from 'yup';
import ValidationErrors from '../errors/ValidationErrors';

export default observer(function LoginForm() {
	const { userStore } = useStore()
	return (
		<Formik
			initialValues={{ fullName: '', username: '', email: '', password: '', error: null }}
			onSubmit={(values, { setErrors }) => userStore.register(values).catch(error =>
				setErrors({ error }))}
			validationSchema={
				Yup.object({
					fullName: Yup.string().required("Full name is required"),
					username: Yup.string().required("Username is required"),
					email: Yup.string().required("Email is required"),
					password: Yup.string().required("Password is required"),
				})
			}>
			{({ handleSubmit, isSubmitting, errors, isValid, dirty }) => (
				<Form className='ui form error' onSubmit={handleSubmit} autoComplete='off'>
					<MyTextInput name='fullName' placeholder='Full Name' readOnly={false} />
					<MyTextInput name='username' placeholder='User Name' readOnly={false} />
					<MyTextInput name='email' placeholder='Email' readOnly={false} />
					<MyTextInput name='password' placeholder='Password' type='password' readOnly={false} />
					<ErrorMessage
						name='error' render={() =>
							<ValidationErrors errors={errors.error} />}
					/>
					<Button disabled={!isValid || !dirty || isSubmitting}
						loading={isSubmitting} color='black' content='Register' type='submit' fluid />
				</Form>
			)}
		</Formik>
	)
})