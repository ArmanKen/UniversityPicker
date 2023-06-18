import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/common/components/LoadingComponent";
import HigherEducationFacilitySettingsHeader from "./HigherEducationFacilitySettingsHeader";
import HigherEducationFacilitySettingsContent from "./HigherEducationFacilitySettingsContent";

export default observer(function HigherEducationFacilitySettings() {
	const { higherEducationFacilityStore: { loadHigherEducationFacility, clearHigherEducationFacility,
		selectedHigherEducationFacility, higherEducationFacilityLoadingInitial } } = useStore();
	const { id } = useParams<{ id: string }>();

	useEffect(() => {
		if (id) loadHigherEducationFacility(id);
		return () => clearHigherEducationFacility();
	}, [clearHigherEducationFacility, id, loadHigherEducationFacility])

	if (higherEducationFacilityLoadingInitial || !selectedHigherEducationFacility)
		return <LoadingComponent content="Завантаження даних ЗВО" />

	return (
		<Grid>
			<Grid.Column width={16}>
				<>
					<HigherEducationFacilitySettingsHeader
						higherEducationFacility={selectedHigherEducationFacility} />
					<HigherEducationFacilitySettingsContent
						higherEducationFacility={selectedHigherEducationFacility} />
				</>
			</Grid.Column>
		</Grid>
	)
})