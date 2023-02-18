import React from "react"
import { Card, Placeholder } from "semantic-ui-react"

export default function UnviersityCardPlaceholder() {
	return (
		<Card
			style={{ minWidth: 220, minHeight: 340 }}
			color='black'>
			<Placeholder style={{ minWidth: 220, minHeight: 150 }}>
				<Placeholder.Image />
			</Placeholder>
			<Card.Content>
				<Placeholder fluid>
					<Placeholder.Header>
						<Placeholder.Line length='full' />
						<Placeholder.Line length='full' />
					</Placeholder.Header>
					<Placeholder.Line length='full' />
					<Placeholder.Line length='full' />
					<Placeholder.Line length='full' />
				</Placeholder>
			</Card.Content>
			<Card.Content extra>
				<Placeholder fluid>
					<Placeholder.Line length='full' />
				</Placeholder>
			</Card.Content>
		</Card>
	)
}