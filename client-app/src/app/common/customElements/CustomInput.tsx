import { observer } from "mobx-react-lite";
import { useState } from "react";
import { Input } from "semantic-ui-react";

interface Props {
	inputValue: string | number | undefined;
	changeValue: (value: any) => void;
	isNumber?: boolean;
	isNegative?: boolean;
	placeholder?: string;
	className?: string;
	loading?: boolean;
	disabled?: boolean;
}

export default observer(function CustomInput({ isNumber, isNegative, placeholder,
	inputValue, changeValue, className, loading, disabled }: Props) {
	const [value, setValue] = useState<number | undefined | string>('');

	return (
		<Input
			value={value || value !== 0 ? value : ''}
			placeholder={placeholder ? placeholder : ''}
			className="customInput"
			loading={loading}
			disabled={disabled}
			onChange={(e, data) => {
				if (isNumber && !data.value.startsWith('-')) {
					let newValue = Number(data.value);
					if (newValue) {
						changeValue(newValue);
						setValue(newValue);
					} else if (data.value === '') {
						changeValue(0);
						setValue('');
					}
				}
				else if (isNegative) {
					if (data.value.startsWith('-') && data.value.length === 1) {
						setValue('-');
						changeValue(0);
					}
					else {
						let newValue = Number(data.value);
						if (newValue) {
							changeValue(newValue);
							setValue(newValue);
						} else if (data.value === '') {
							changeValue(0);
							setValue(newValue);
						}
					}
				}
				else if (!isNumber && !isNegative) {
					changeValue(data.value);
				}
			}}
		/>
	)
})