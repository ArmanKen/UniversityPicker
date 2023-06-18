import { observer } from "mobx-react-lite"
import { Profile } from "../../app/models/profile";
import { useStore } from "../../app/stores/store";
import { Tab } from "semantic-ui-react";
import ProfileInfo from "./ProfileInfo";
import { useState } from "react";
import ProfileFavorites from "./ProfileFavorites";
import ProfileAdminBar from "./ProfileAdminBar";

interface Props {
	profile: Profile;
}

export default observer(function ProfileContent({ profile }: Props) {
	const { profileStore: { activeTab, setActiveTab },
		userStore: { isGlobalAdmin, getIsGlobalAdmin } } = useStore();
	const [editMode, setEditMode] = useState(false);

	getIsGlobalAdmin();

	let panes = [
		{ menuItem: 'Інформація', render: () => <ProfileInfo setEditMode={setEditMode} editMode={editMode} /> },
		{ menuItem: 'Закладки', render: () => <ProfileFavorites /> },
	];

	if (isGlobalAdmin)
		panes = [
			{ menuItem: 'Інформація', render: () => <ProfileInfo setEditMode={setEditMode} editMode={editMode} /> },
			{ menuItem: 'Закладки', render: () => <ProfileFavorites /> },
			{ menuItem: 'Панель Адміністратора', render: () => <ProfileAdminBar /> }
		];

	return (
		<Tab
			menu={{ fluid: true, vertical: true }}
			menuPosition='right'
			panes={panes}
			activeIndex={activeTab}
			onTabChange={(e, data) => setActiveTab(data.activeIndex)}
		/>
	)
})