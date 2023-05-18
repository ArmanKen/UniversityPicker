import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { Button } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function HigherEducationFacilityShortInfoAction() {
	const { higherEducationFacilityStore: { selectedHigherEducationFacility }, modalStore: { closeModal } } = useStore();

	return (
		<Button color="black" fluid size="big"
			as={Link} to={`higherEducationFacility/${selectedHigherEducationFacility?.id}`}
			onClick={closeModal}>
			Детальніше про університет
		</Button>
	)
})