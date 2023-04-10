import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Header, Icon, Segment } from 'semantic-ui-react';

export default function NotFound() {
	return (
		<Segment placeholder>
			<Header icon>
				<Icon name='search' />
				Нічого не змогли знайти за цим посиланням.
			</Header>
			<Segment.Inline>
				<Button as={Link} to='/' primary>
					Повернутися до головної сторінки.
				</Button>
			</Segment.Inline>
		</Segment>
	)
}