import { observer } from "mobx-react-lite"
import { Profile } from "../../app/models/profile";
import { Header, Image, Segment } from "semantic-ui-react";

interface Props {
	profile: Profile;
}

export default observer(function ProfileHeader({ profile }: Props) {
	return (
		<Segment textAlign="center">
			<Image circular size="small" verticalAlign="middle"
				src={(profile.photo && profile.photo.url) || "../assets/149071.png"} />
			<Header
				content={profile.username}
				style={{ marginTop: 15 }}
				size="large"
			/>
		</Segment>
	)
})