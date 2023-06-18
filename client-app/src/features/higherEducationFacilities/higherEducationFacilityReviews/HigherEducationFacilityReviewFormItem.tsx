import { observer } from "mobx-react-lite";
import { Button, Form, Header, Icon, Image, Rating, Segment } from "semantic-ui-react";
import { format } from "date-fns";
import { Formik } from "formik";
import { useStore } from "../../../app/stores/store";
import * as Yup from 'yup';
import MyTextArea from "../../../app/common/form/MyTextArea";
import { Review } from "../../../app/models/review";

interface Props {
	higherEducationFacilityId: string;
	setEditMode: (editMode: boolean) => void;
	editMode: boolean;
	review: Review;
}

export default observer(function HigherEducationFacilityReviewFormItem({
	higherEducationFacilityId, setEditMode, editMode, review }: Props) {

	const { reviewStore: { editReview } } = useStore()

	return (
		<Segment>
			<Formik
				initialValues={{
					id: review.id,
					rating: review.rating,
					body: review.body
				}}
				onSubmit={values => {
					console.log('lol');
					editReview(higherEducationFacilityId, values).then(() => {
						setEditMode(false);
					})
				}}
				validationSchema={
					Yup.object({
						id: Yup.string().required(),
						body: Yup.string().required()
					})
				}
			>
				{({ isSubmitting, isValid, dirty, resetForm, setFieldValue, values }) => (
					<Form className='ui form'>
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
						<Image circular src={review?.image || "../assets/149071.png"} size="tiny" floated="left" />
						<Header content={review?.fullName} floated="left" />
						<Rating size='huge' maxRating={5} style={{ marginLeft: 3 }}
							disabled={!editMode} rating={values.rating}
							onRate={(e, d) => {
								setFieldValue('rating', d.rating as number);
							}}
							icon="star" clearable />
						<p style={{ width: 200 }}>{format(review.createdAt, 'dd MMM yyyy h:mm aa')}</p>
						<MyTextArea rows={4} placeholder='Напишіть відгук' name="body" readOnly={!editMode} />
					</Form>
				)}
			</Formik >
		</Segment>
	)
})