import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Divider, Grid } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import LoadingComponent from "../../../app/common/components/LoadingComponent";
import SpecialtyMainInfo from "./SpecialtyMainInfo";
import EduComponentsCardList from "../../eduComponents/EduComponentsCardList";

export default observer(function SpecialtyPage() {
	const { specilatyStore: { loadSpecialty, specialtyLoadingInitial, selectedSpecialty },
		eduComponentStore: { loadEduComponents, clearEduComponents } } = useStore();
	const { id } = useParams<{ id: string }>();

	useEffect(() => {
		if (id) {
			loadSpecialty(id);
			loadEduComponents(id);
		}
		return () => clearEduComponents();
	}, [loadSpecialty, id, loadEduComponents, clearEduComponents])

	if (specialtyLoadingInitial || !selectedSpecialty)
		return <LoadingComponent content="Завантаження даних про Спеціальність" />

	return (
		<Grid>
			<Grid.Row>
				<SpecialtyMainInfo specialty={selectedSpecialty}/>
			</Grid.Row>
			<Divider hidden style={{ padding: 0, margin: 0 }} />
			<Grid.Row>
				<EduComponentsCardList/>
			</Grid.Row>
		</Grid>
	)
})