import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Accordion, Grid, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import SpecialtyItem from "./SpecialtyItem";

interface Props {
	facultyId: string
}

export default observer(function SpecialtyItemsList({ facultyId }: Props) {
	const { specilatyStore: { junBachelorSpecialties,
		bachelorSpecialties, magisterSpecialties, loadSpecialties, clearSpecialties } } = useStore()

	const [active, setActive] = useState(0);

	const toggleActive = (position: number) => {
		setActive(active === position ? 0 : position);
	};

	useEffect(() => {
		if (junBachelorSpecialties.size < 1 || bachelorSpecialties.size < 1 || magisterSpecialties.size < 1) {
			loadSpecialties(facultyId);
		}
		return () => clearSpecialties();
	}, [loadSpecialties, facultyId, clearSpecialties,
		junBachelorSpecialties.size, bachelorSpecialties.size, magisterSpecialties.size])


	return (
		<Grid centered stackable stretched>
			<Segment>
				<Header style={{ width: 1000 }}>Спеціальності</Header>
			</Segment>
			<Accordion styled fluid>
				<Accordion.Title active={active === 1} onClick={x => toggleActive(1)} content='Молодший бакалавр' />
				<Accordion.Content active={active === 1}>
					{Array.from(junBachelorSpecialties.values()).map(specialty =>
						<SpecialtyItem specialty={specialty} key={specialty.id} />)}
				</Accordion.Content>
				<Accordion.Title active={active === 2} onClick={x => toggleActive(2)} content='Бакалавр' />
				<Accordion.Content active={active === 2}>
					{Array.from(bachelorSpecialties.values()).map(specialty =>
						<SpecialtyItem specialty={specialty} key={specialty.id} />)}
				</Accordion.Content>
				<Accordion.Title active={active === 3} onClick={x => toggleActive(3)} content='Магістр' />
				<Accordion.Content active={active === 3}>
					{Array.from(magisterSpecialties.values()).map(specialty =>
						<SpecialtyItem specialty={specialty} key={specialty.id} />)}
				</Accordion.Content>
			</Accordion>

		</Grid>
	)
})