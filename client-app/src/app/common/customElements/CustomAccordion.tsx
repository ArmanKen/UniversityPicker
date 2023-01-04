import { observer } from "mobx-react-lite";
import { useState } from "react";
import { Accordion, Header } from "semantic-ui-react";

interface Props {
	title?: string;
	content: JSX.Element;

}

export default observer(function CustomAccordion({ title, content }: Props) {
	const [active, setActive] = useState(false);

	return (
		<Accordion fluid className='customAccordion'>
			<Accordion.Title
				as={Header}
				size='small'
				active={active}
				content={title ? title : ''}
				onClick={() => setActive(!active)}
			/>
			<Accordion.Content
				active={active}
				content={content}
			/>
		</Accordion>
	);
})