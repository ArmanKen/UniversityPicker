import { observer } from "mobx-react-lite";
import * as Yup from 'yup';
import MyTextInput from "../../app/common/form/MyTextInput";
import { Form, Formik } from "formik";
import { useStore } from "../../app/stores/store";
import { Accordion, Button, Icon, Label, Segment } from "semantic-ui-react";
import MyTextArea from "../../app/common/form/MyTextArea";
import { v4 as uuid } from 'uuid';
import MySelectInput from "../../app/common/form/MySelectInput";
import { useState } from "react";

export default observer(function ProfileAdminBar() {
	const [active, setActive] = useState(0);
	const {
		higherEducationFacilityStore: { deleteHigherEducationFacility, createHigherEducationFacility },
		uiStore: { accreditations, regions, cities } } = useStore()

	const toggleActive = (position: number) => {
		setActive(active === position ? 0 : position);
	};

	return (
		<Segment>
			<Accordion>
				<Accordion.Title active={active === 1} onClick={x => toggleActive(1)} content='Створити заклад вищої освіти' />
				<Accordion.Content active={active === 1}>
					<Formik
						initialValues={{
							id: uuid(),
							name: '',
							accreditation: 0,
							region: 0,
							city: 0,
							address: '',
							website: '',
							info: '',
							telephone: '',
							ukraineTop: 0,
							titlePhoto: '',
						}}
						onSubmit={values => {
							createHigherEducationFacility(values);
						}}
						validationSchema={
							Yup.object({
								name: Yup.string().required("Назва обов'язкове поле")
							})
						}
					>
						{({ isSubmitting, isValid, dirty }) => (
							<Form className='ui form' >
								<Label basic>Назва ЗВО</Label>
								<MyTextInput placeholder="Повна назва" name="name" readOnly={false} />
								<Label basic>Про ЗВО</Label>
								<MyTextArea rows={4} placeholder='Інформація про ЗВО' name="info" readOnly={false} />
								<Label basic>Веб-Сторінку</Label>
								<MyTextInput placeholder="Посилання на Веб-Сторінку" name="website" readOnly={false} />
								<Label basic>Регіон</Label>
								<MySelectInput
									placeholder="Регіон"
									name="region"
									options={Array.from(regions.keys())}
									readOnly={false} />
								<Label basic>Місто</Label>
								<MySelectInput
									placeholder="Місто"
									name="city"
									options={cities}
									readOnly={false} />
								<Label basic>Адреса</Label>
								<MyTextInput placeholder="Адреса" name="address" readOnly={false} />
								<Label basic>Телефон</Label>
								<MyTextInput placeholder="Телефон" name="telephone" readOnly={false} />
								<Label basic>Місто у рейтингу ЗВО</Label>
								<MyTextInput placeholder="Місто у рейтингу ЗВО" name="ukraineTop" readOnly={false} />
								<Label basic>Аккредитація ЗВО</Label>
								<MySelectInput
									placeholder="Аккредитація ЗВО"
									name="accreditation"
									options={accreditations}
									readOnly={false} />
								<Button icon size="tiny"
									type="submit"
									color="green"
									loading={isSubmitting}
									disabled={!isValid || !dirty}>
									{'Створити ЗВО  '}
									<Icon name="check" />
								</Button>
							</Form>
						)
						}
					</Formik >
				</Accordion.Content>
				<Accordion.Title active={active === 2} onClick={x => toggleActive(2)} content='Видалити заклад вищої освіти' />
				<Accordion.Content active={active === 2}>
					<Formik
						initialValues={{
							higherEducationFacilityId: ''
						}}
						onSubmit={values => {
							deleteHigherEducationFacility(values);
						}}
						validationSchema={
							Yup.object({
								name: Yup.string().required("ID обов'язкове поле")
							})
						}
					>
						{({ isSubmitting, isValid, dirty }) => (
							<Form className='ui form' >
								<Label basic>Id ЗВО</Label>
								<MyTextInput placeholder="Id" name="higherEducationFacilityId" readOnly={false} />
								<Button icon size="tiny"
									type="submit"
									color="red"
									loading={isSubmitting}
									disabled={!isValid || !dirty}>
									{'Видалити ЗВО  '}
									<Icon name="check" />
								</Button>
							</Form>
						)
						}
					</Formik >
				</Accordion.Content>
			</Accordion>
		</Segment>
	)
})