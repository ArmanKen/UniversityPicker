import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { Button } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function UniversityShortInfoAction() {
	const { universityStore: { selectedUniversity }, modalStore: { closeModal } } = useStore();

	return (
		<Button color="black" fluid size="big"
			as={Link} to={`university/${selectedUniversity?.id}`}
			onClick={closeModal}>
			Детальніше про університет
		</Button>
	)
})