import { observer } from "mobx-react-lite";
import { Card, Icon, Image, Transition } from "semantic-ui-react";
import { University } from "../../../app/models/university";
import { useStore } from "../../../app/stores/store";
import UniversityShortInfoAction from "../universityModal/UniversityShortInfoAction";
import UniversityShortInfoContent from "../universityModal/UniversityShortInfoContent";

interface Props {
	university: University
}

export default observer(function UniversityCard({ university }: Props) {
	const { universityStore: { setUniversity }, modalStore: { openModal } } = useStore();

	return (
		<Transition animation="fade" duration={300}
			unmountOnHide={true} transitionOnMount={true}>
			<Card fluid raised
				style={{
					minWidth: 222,
				}}
				onClick={() => {
					setUniversity(university);
					openModal(<>Про університет</>,
						<UniversityShortInfoContent />, 'small',
						<UniversityShortInfoAction />);
				}}>
				<div style={{ position: "relative", display: "flex" }}>
					<Image fluid src={university.titlePhoto
						|| '../defaultLogo.png'} />
					<div className="square" style={{ position: 'absolute', bottom: 0 }}>
						<Icon name='star' size='large'
							style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
							{university.rating.toFixed(1)}
						</Icon>
					</div>
				</div>
				<Card.Content textAlign="center" style={{ fontWeight: 600, fontSize: '0.9rem' }}>
					<Card.Header content={university.name} />
				</Card.Content>
			</Card>
		</Transition>
	)
})