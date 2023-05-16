import { Button } from "semantic-ui-react";

export default function ScrollToTop() {

	return (
		<Button
			color="black"
			floated="right"
			style={{ position: 'fixed', bottom: 20, right: 20, zIndex: 800 }}
			onClick={() => {
				window.focus();
				window.scrollTo({ top: 0, behavior: 'smooth' });
			}}
			circular
			size='big'
			icon='arrow alternate circle up'>
		</Button>
	)
}