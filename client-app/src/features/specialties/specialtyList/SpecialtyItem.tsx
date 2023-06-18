import { observer } from "mobx-react-lite";
import { Item } from "semantic-ui-react";
import { Specialty } from "../../../app/models/specialty";

interface Props {
	specialty: Specialty
}

export default observer(function SpecialtyItem({ specialty }: Props) {

	console.log(specialty);
	return (
		<Item>
			<Item.Header>{specialty.specialtyBase.name}</Item.Header>
		</Item>
	)
})