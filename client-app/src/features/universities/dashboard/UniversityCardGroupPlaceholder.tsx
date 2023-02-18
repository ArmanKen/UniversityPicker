import React from 'react'
import { Card } from 'semantic-ui-react'
import UnviersityCardPlaceholder from './UniverisityCardPlaceholder'

export default function UniversityCardGroupPlaceholder() {
	return (
		<Card.Group doubling itemsPerRow={4} style={{ marginTop: -9 }}>
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
			<UnviersityCardPlaceholder />
		</Card.Group>
	)
}