import React from "react";
import { Link } from "react-router-dom";
import { Button, Container, Header, Segment } from "semantic-ui-react";

export default function HomePage() {
	return (
		<Segment inverted textAlign='center' vertical className='masthead'>
			<Container text>
				<Header as='h1' inverted>
					{/* <Image size='massive' src='/assets/logo.png' alt='logo' style={{ marginBottom: 12 }} /> */}
					{/*some text*/}
					UniversityPicker
				</Header>
				<Button as={Link} to='/branchesOfKnowledge' massive inverted>Start pick</Button>
			</Container>
		</Segment>)
}