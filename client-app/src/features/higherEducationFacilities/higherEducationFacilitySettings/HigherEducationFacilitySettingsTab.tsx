import { observer } from "mobx-react-lite";
import * as Yup from 'yup';
import { Form, Formik } from "formik";
import { Accordion, Button, Icon, Label, Segment } from "semantic-ui-react";
import { useState } from "react";
import { useStore } from "../../../app/stores/store";
import MyTextInput from "../../../app/common/form/MyTextInput";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";
import MySelectInput from "../../../app/common/form/MySelectInput";
import MyTextArea from "../../../app/common/form/MyTextArea";
import { Link } from "react-router-dom";
import PhotoUploadWidget from "../../../app/common/imageUpload/PhotoUploadWidget";
import HigherEducationFacilityGallery from "../higherEducationFacilityGallery/HigherEducationFacilityGallery";

interface Props {
	higherEducationFacility: HigherEducationFacility;
}

export default observer(function HigherEducationFacilitySettingsTab({ higherEducationFacility }: Props) {
	const [active, setActive] = useState(0);
	const {
		higherEducationFacilityStore: { deleteHigherEducationFacility,
			editHigherEducationFacility, higherEducationFacilityLoadingInitial },
		uiStore: { accreditations, regions, cities },
		photoStore: { addHigherEducationFacilityTitlePhoto, deleteHigherEducationFacilityTitlePhoto,
			deletePhoto, addHigherEducationFacilityGalleryPhoto, photoLoadingInitial, selectedPhoto } } = useStore()

	const toggleActive = (position: number) => {
		setActive(active === position ? 0 : position);
	};

	return (
		<Segment>
			<Accordion>
				<Accordion.Title active={active === 1} onClick={x => toggleActive(1)} content='Змінити інформацію про ЗВО' />
				<Accordion.Content active={active === 1}>
					<Formik
						initialValues={{
							id: higherEducationFacility.id,
							name: higherEducationFacility.name,
							accreditation: higherEducationFacility.accreditation.id,
							region: higherEducationFacility.region ? higherEducationFacility.region.id : 0,
							city: higherEducationFacility.city ? higherEducationFacility.city.id : 0,
							address: higherEducationFacility.address,
							website: higherEducationFacility.website,
							info: higherEducationFacility.info,
							telephone: higherEducationFacility.telephone,
							ukraineTop: higherEducationFacility.ukraineTop,
							titlePhoto: higherEducationFacility.titlePhoto,
							locationLat: higherEducationFacility.location ? higherEducationFacility.location.latitude : 0,
							locationLong: higherEducationFacility.location ? higherEducationFacility.location.longitude : 0,
						}}
						onSubmit={values => {
							editHigherEducationFacility(values);
						}}
						validationSchema={
							Yup.object({
								name: Yup.string().required("Назва обов'язкове поле")
							})
						}
					>
						{({ isSubmitting, isValid, dirty, resetForm }) => (
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
								<Label basic>Координати Latitude та Longitude</Label>
								<MyTextInput placeholder="Latitude" name="locationLat" readOnly={false} />
								<MyTextInput placeholder="Longitude" name="locationLong" readOnly={false} />
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
									{'Змінити ЗВО  '}
									<Icon name="check" />
								</Button>
								<Button icon size="tiny"
									type="button"
									onClick={x => resetForm()}
									color="red">
									{'Відмінити зміни '}
									<Icon name="x" />
								</Button>
							</Form>
						)
						}
					</Formik >
				</Accordion.Content>
				<Accordion.Title active={active === 2} onClick={x => toggleActive(2)} content='Змінити головну фотографію ЗВО' />
				<Accordion.Content active={active === 2}>
					<PhotoUploadWidget loading={photoLoadingInitial} uploadPhoto={addHigherEducationFacilityTitlePhoto} />
				</Accordion.Content>
				<Accordion.Title active={active === 3} onClick={x => toggleActive(3)} content='Додати фотографію до галереї ЗВО' />
				<Accordion.Content active={active === 3}>
					<PhotoUploadWidget loading={photoLoadingInitial} uploadPhoto={addHigherEducationFacilityGalleryPhoto} />
				</Accordion.Content>
				<Accordion.Title active={active === 4} onClick={x => toggleActive(4)} content='Видалити головну фотографію ЗВО' />
				<Accordion.Content active={active === 4}>
					<Button icon
						color="red"
						loading={photoLoadingInitial}
						disabled={!higherEducationFacility.titlePhoto}
						onClick={x => deleteHigherEducationFacilityTitlePhoto(higherEducationFacility.id)}>
						{'Видалити головну фотографію ЗВО  '}
						<Icon name="check" />
					</Button>
				</Accordion.Content>
				<Accordion.Title active={active === 5} onClick={x => toggleActive(5)} content='Видалити фотографію з галереї ЗВО' />
				<Accordion.Content active={active === 5}>
					<HigherEducationFacilityGallery higherEducationFacilityId={higherEducationFacility.id} />
					<Button icon
						color="red"
						disabled={!selectedPhoto}
						loading={photoLoadingInitial}
						onClick={x => deletePhoto(higherEducationFacility.id, selectedPhoto ? selectedPhoto.id : "")}>
						{'Видалити фотографію з галереї ЗВО  '}
						<Icon name="check" />
					</Button>
				</Accordion.Content>
				<Accordion.Title active={active === 6} onClick={x => toggleActive(6)} content='Видалити заклад вищої освіти' />
				<Accordion.Content active={active === 6}>
					<Button icon
						color="red"
						loading={higherEducationFacilityLoadingInitial}
						as={Link} to='/'
						onClick={x => deleteHigherEducationFacility({ higherEducationFacilityId: higherEducationFacility.id })}>
						{'Видалити ЗВО  '}
						<Icon name="check" />
					</Button>
				</Accordion.Content>
			</Accordion>
		</Segment>
	)
})