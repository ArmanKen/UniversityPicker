import { observer } from "mobx-react-lite";
import { useState } from "react";
import { Accordion, Card, Grid, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import SpecialtyItem from "./SpecialtyCard";

interface Props {
	facultyId: string
}

export default observer(function SpecialtyCardList({ facultyId }: Props) {
	const { specilatyStore: { junBachelorSpecialties,
		bachelorSpecialties, magisterSpecialties } } = useStore()

	const [active, setActive] = useState(0);

	const toggleActive = (position: number) => {
		setActive(active === position ? 0 : position);
	};

	return (
		<Grid centered stackable stretched>
			<Segment>
				<Header style={{ width: 1200 }} textAlign="center">Спеціальності</Header>
			</Segment>
			<Accordion styled fluid style={{ maxWidth: 1200, margin: '0 auto' }} >
				<Accordion.Title active={active === 1} onClick={x => toggleActive(1)} content='Молодший бакалавр' />
				<Accordion.Content active={active === 1}>
					<Card.Group centered>
						{Array.from(junBachelorSpecialties.values()).map(specialty =>
							<SpecialtyItem specialty={specialty} key={specialty.id} />)}
					</Card.Group>
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