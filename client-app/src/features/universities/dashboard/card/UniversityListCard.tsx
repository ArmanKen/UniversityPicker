import { observer } from "mobx-react-lite";
import { Card, Icon, Image, Transition } from "semantic-ui-react";
import { University } from "../../../../app/models/university";
import { useStore } from "../../../../app/stores/store";
import UniversityShortInfoAction from "./../shortInfo/UniversityShortInfoAction";
import UniversityShortInfoContent from "./../shortInfo/UniversityShortInfoContent";

interface Props {
	university: University
}

export default observer(function UniversityListCard({ university }: Props) {
	const { universityStore: { setUniversity }, modalStore: { openModal } } = useStore();

	return (
		<Transition animation="fade" duration={300}
			unmountOnHide={true} transitionOnMount={true}>
			<Card raised style={{ width: 250, height: 250 }}
				onClick={() => {
					setUniversity(university);
					openModal(<>Про університет</>,
						<UniversityShortInfoContent />, <UniversityShortInfoAction />, 'small');
				}}>
				<div style={{ position: "relative", display: "flex" }}>
					<Image fluid style={{ width: 250, height: 150 }} src='assets/1.png' />
					<div className="square" style={{ position: 'absolute', bottom: 0 }}>
						<Icon name='star' size='large'
							style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
							{university.rating.toFixed(1)}
						</Icon>
					</div>
				</div>
				<Card.Content textAlign="center" style={{ fontSize: '0.9em', fontWeight: 600, height: 150 }}>
					<Card.Header content={university.name} />
				</Card.Content>
			</Card>
		</Transition>
	)
})