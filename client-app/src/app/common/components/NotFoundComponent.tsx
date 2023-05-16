import { Segment } from "semantic-ui-react";

interface Props {
	content?: string
}

export default function NotFoundComponent({ content = 'Нічого не знайдено' }: Props) {
	return (
		<Segment textAlign="center" color="grey" inverted
			style={{ fontSize: '1.2rem', marginTop: 20 }}>
			{content}
		</Segment>
	)
}