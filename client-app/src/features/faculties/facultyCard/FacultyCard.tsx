import { observer } from "mobx-react-lite";
import { Card, Image, Transition } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { Faculty } from "../../../app/models/faculty";

interface Props {
	faculty: Faculty
}

export default observer(function FacultyCard({ faculty }: Props) {
	const { facultyStore: { setFaculty } } = useStore();
	//TODO сделать списком

	return (
		<Transition animation="fade" duration={300}
			unmountOnHide={true} transitionOnMount={true}>
			<Card fluid raised
				style={{ minWidth: 200, maxWidth: 350 }}
				onClick={() => setFaculty(faculty)}	>
				<Image fluid src={(faculty.facultyPhoto && faculty.facultyPhoto.url)
					|| '../facultyLogo.png'} />
				<Card.Content textAlign="center"
					style={{ fontWeight: 600, fontSize: '1.1rem' }}>
					<Card.Header content={faculty.name} />
					<Card.Description style={{ fontWeight: 600, fontSize: '1rem' }}>
						{'Області знань факультету: '}
						{faculty.knowledgeBranches.length > 0 ?
							faculty.knowledgeBranches.map(knowledgeBranch =>
								<div style={{ whiteSpace: 'pre-line' }}>
									{knowledgeBranch.name + '\n'}
								</div>) : 'Області знань не зазначені'}
					</Card.Description>
				</Card.Content>
			</Card>
		</Transition>
	)
})