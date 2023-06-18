import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { useStore } from "../../app/stores/store";
import { Grid } from "semantic-ui-react";
import ProfileHeader from "./ProfileHeader";
import ProfileContent from "./ProfileContent";
import LoadingComponent from "../../app/common/components/LoadingComponent";

export default observer(function ProfilePage() {
	const { profileStore: { loadProfile, clearProfile, profile, profileLoadingInitial, setActiveTab } } = useStore();
	const { id } = useParams<{ id: string }>();

	useEffect(() => {
		if (id) loadProfile(id);
		return () => {
			clearProfile();
			setActiveTab(0);
		}
	}, [loadProfile, id, clearProfile, setActiveTab])

	if (profileLoadingInitial) return <LoadingComponent content='Завантаження даних профіля' />

	return (
		<Grid>
			<Grid.Column width={16}>
				{profile && (
					<>
						<ProfileHeader profile={profile} />
						<ProfileContent profile={profile} />
					</>
				)}
			</Grid.Column>
		</Grid>
	)
})