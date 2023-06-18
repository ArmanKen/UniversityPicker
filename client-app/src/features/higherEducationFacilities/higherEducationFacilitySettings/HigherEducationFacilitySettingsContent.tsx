import { observer } from "mobx-react-lite"
import { Tab } from "semantic-ui-react";
import { HigherEducationFacility } from "../../../app/models/higherEducationFacility";
import { useStore } from "../../../app/stores/store";
import HigherEducationFacilitySettingsTab from "./HigherEducationFacilitySettingsTab";

interface Props {
	higherEducationFacility: HigherEducationFacility;
}

export default observer(function HigherEducationFacilitySettingsContent({ higherEducationFacility }: Props) {
	const { higherEducationFacilityStore: { activeTab, setActiveTab }, } = useStore();

	const panes = [
		{ menuItem: 'Налаштування ЗВО', render: () => <HigherEducationFacilitySettingsTab higherEducationFacility={higherEducationFacility} /> },
		{ menuItem: 'Налаштування Факультетів', render: () => <></> },
		{ menuItem: 'Налаштування Спеціальностей', render: () => <></> },
		{ menuItem: 'Налаштування Освітніх Компонентів', render: () => <></> },
	];

	return (
		<Tab
			menu={{ fluid: true, vertical: true }}
			menuPosition='left'
			panes={panes}
			activeIndex={activeTab}
			onTabChange={(e, data) => setActiveTab(data.activeIndex)}
		/>
	)
})