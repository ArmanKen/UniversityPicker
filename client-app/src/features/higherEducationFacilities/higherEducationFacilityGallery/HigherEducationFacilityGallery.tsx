import { observer } from "mobx-react-lite";
import { Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { useEffect } from "react";
import { PagingParams } from "../../../app/models/pagination";
import NotFoundComponent from "../../../app/common/components/NotFoundComponent";
import InfiniteScroll from "react-infinite-scroll-component";
import HigherEducationFacilityGalleryList from "./HigherEducationFacilityGalleryList";

interface Props {
	higherEducationFacilityId: string;
}

export default observer(function HigherEducationFacilityGallery({ higherEducationFacilityId }: Props) {
	const { photoStore: { gallery, loadPhotos, photoLoadingInitial,
		pagination, setPagingParams, setSelectedPhoto } } = useStore();

	useEffect(() => {
		if (gallery.size < 1)
			loadPhotos(higherEducationFacilityId);
	}, [loadPhotos, gallery.size, higherEducationFacilityId])

	function handleGetNext() {
		if (!photoLoadingInitial) {
			setPagingParams(new PagingParams(pagination!.currentPage + 1));
			loadPhotos(higherEducationFacilityId);
		}
	}

	return (
		<Segment compact style={{ margin: '0 auto' }}>
			<Header content='Галерея ЗВО' textAlign="center" style={{ marginTop: 0, marginBottom: 20 }} />
			{!photoLoadingInitial && gallery.size < 1 ?
				<NotFoundComponent content="Немає фотографій" /> :
				<InfiniteScroll style={{ overflow: 'hidden', paddingTop: 20 }}
					dataLength={gallery.size} next={handleGetNext} loader=''
					hasMore={!photoLoadingInitial && !!pagination
						&& pagination.currentPage < pagination.totalPages}>
					<HigherEducationFacilityGalleryList gallery={gallery} setSelectedPhoto={setSelectedPhoto} />
				</InfiniteScroll>
			}
		</Segment>
	)
})