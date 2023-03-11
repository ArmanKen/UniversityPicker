import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { Button, Modal } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";

export default observer(function UniversityModalActions() {
	const { universityStore: { selectedUniversity } } = useStore();

	return (
		<Modal.Content>
			<Button color="black" fluid size="big"
				as={Link} to={`university/${selectedUniversity?.id}`}
				target="_blank" rel="noopener noreferrer">
				Детальніше про університет
			</Button>
		</Modal.Content>
	)
})