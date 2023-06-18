import { observer } from "mobx-react-lite";
import * as Yup from 'yup';
import MyTextInput from "../../app/common/form/MyTextInput";
import { Form, Formik } from "formik";
import { useStore } from "../../app/stores/store";
import { Button, Divider, Icon, Label, Segment } from "semantic-ui-react";
import MyTextArea from "../../app/common/form/MyTextArea";
import PhotoUploadWidget from "../../app/common/imageUpload/PhotoUploadWidget";
import MySelectInput from "../../app/common/form/MySelectInput";

interface Props {
	setEditMode: (editMode: boolean) => void;
	editMode: boolean;
}

export default observer(function ProfileInfo({ setEditMode, editMode }: Props) {
	const { profileStore: { profile, editProfile, isCurrentUser },
		uiStore: { currentStatuses, degrees, specialtyBases },
		photoStore: { addUserPhoto, photoLoadingInitial } } = useStore()

	return (
		<Segment>
			<Formik
				initialValues={{
					fullName: profile?.fullName ? profile?.fullName : "",
					bio: profile?.bio ? profile?.bio : "",
					currentStatus: profile?.currentStatus ? profile?.currentStatus.id : 0,
					specialtyBase: profile?.specialtyBase ? profile?.specialtyBase.name : "",
					degree: profile?.degree ? profile?.degree.id : 0
				}}
				onSubmit={values => {
					editProfile(values).then(() => {
						setEditMode(false);
					})
				}}
				validationSchema={
					Yup.object({
						fullName: Yup.string().required()
					})
				}
			>
				{({ isSubmitting, isValid, dirty, resetForm }) => (
					<Form className='ui form' >
						Інформація про користувача
						{editMode ?
							<>
								<Button icon size="tiny" basic floated="right"
									type="button" compact circular
									color="red"
									onClick={x => {
										setEditMode(!editMode);
										resetForm();
									}}>
									<Icon name="x" color="red" />
								</Button>
								<Button icon size="tiny" basic floated="right"
									type="submit" compact circular
									color="green"
									loading={isSubmitting}
									disabled={!isValid || !dirty}>
									<Icon name="check" color="green" />
								</Button>
							</>
							:
							<Button icon size="tiny" basic floated="right"
								type="button" secondary compact circular
								onClick={x => setEditMode(!editMode)}>
								<Icon name="pencil alternate" color="black" />
							</Button>}
						<Divider />
						<Label basic>Повне імя</Label>
						<MyTextInput placeholder="Full Name" name="fullName" readOnly={!editMode} />
						<Label basic>Про себе</Label>
						<MyTextArea rows={4} placeholder='Add your bio' name="bio" readOnly={!editMode} />
						<Label basic>Статус</Label>
						<MySelectInput
							placeholder="Статус"
							name="currentStatus"
							options={currentStatuses}
							readOnly={!editMode} />
						<Label basic>Освітня ступінь</Label>
						<MySelectInput
							placeholder="Освітня ступінь"
							name="degree"
							options={degrees}
							readOnly={!editMode} />
						<Label basic>Спеціальність</Label>
						<MySelectInput
							placeholder="Спеціальність"
							name="specialtyBase"
							options={specialtyBases}
							readOnly={!editMode} />
					</Form>
				)
				}
			</Formik >
			<Divider />
			{isCurrentUser &&
				<PhotoUploadWidget loading={photoLoadingInitial} uploadPhoto={addUserPhoto} />}
		</Segment>
	)
})