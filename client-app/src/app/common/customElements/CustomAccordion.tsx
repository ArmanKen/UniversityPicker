import { observer } from "mobx-react-lite";
import { useState } from "react";
import { Accordion, Header } from "semantic-ui-react";

interface Props {
	content: JSX.Element;
	title?: string;
	size?: 'tiny' | 'small' | 'medium' | 'large' | 'huge';
	className?: string;
}

export default observer(function CustomAccordion({ title, content, size, className }: Props) {
	const [active, setActive] = useState(false);

	return (
		<Accordion fluid className='custom-accordion'>
			<Accordion.Title
				as={Header}
				size={size ? size : 'small'}
				active={active}
				content={title ? title : null}
				onClick={() => setActive(!active)}
				className={className}
			/>
			<Accordion.Content
				active={active}
				content={content}
			/>
		</Accordion>
	);
})