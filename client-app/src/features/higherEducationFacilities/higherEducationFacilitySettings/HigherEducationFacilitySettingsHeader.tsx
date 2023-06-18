import { observer } from "mobx-react-lite"
import { Header, Segment } from "semantic-ui-react";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";

interface Props {
	higherEducationFacility: HigherEducationFacility;
}

export default observer(function HigherEducationFacilitySettingsHeader({ higherEducationFacility }: Props) {
	return (
		<Segment textAlign="center">
			<Header
				content={higherEducationFacility.name}
				style={{ marginTop: 15 }}
				size="large"
			/>
		</Segment>
	)
})