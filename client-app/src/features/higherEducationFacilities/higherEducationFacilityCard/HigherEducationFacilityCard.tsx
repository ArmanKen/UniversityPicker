import { observer } from "mobx-react-lite";
import { Card, Icon, Image, Transition } from "semantic-ui-react";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";
import { useStore } from "../../../app/stores/store";
import HigherEducationFacilityShortInfoAction from "../higherEducationFacilityModal/HigherEducationFacilityShortInfoAction";
import HigherEducationFacilityShortInfoContent from "../higherEducationFacilityModal/HigherEducationFacilityShortInfoContent";

interface Props {
	higherEducationFacility: HigherEducationFacility
}

export default observer(function HigherEducationFacilityCard({ higherEducationFacility }: Props) {
	const { higherEducationFacilityStore: { setHigherEducationFacility }, modalStore: { openModal } } = useStore();

	return (
		<Transition animation="fade" duration={300}
			unmountOnHide={true} transitionOnMount={true}>
			<Card fluid raised
				style={{
					minWidth: 222,
				}}
				onClick={() => {
					setHigherEducationFacility(higherEducationFacility);
					openModal(<>Про університет</>,
						<HigherEducationFacilityShortInfoContent />, 'small',
						<HigherEducationFacilityShortInfoAction />);
				}}>
				<div style={{ position: "relative", display: "flex" }}>
					<Image fluid src={higherEducationFacility.titlePhoto
						|| '../defaultLogo.png'} />
					<div className="square" style={{ position: 'absolute', bottom: 0 }}>
						<Icon name='star' size='large'
							style={{ color: 'white', marginTop: 9, marginLeft: 5 }}	>
							{higherEducationFacility.rating.toFixed(1)}
						</Icon>
					</div>
				</div>
				<Card.Content textAlign="center" style={{ fontWeight: 600, fontSize: '0.9rem' }}>
					<Card.Header content={higherEducationFacility.name} />
				</Card.Content>
			</Card>
		</Transition>
	)
})