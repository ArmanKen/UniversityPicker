import React, { useEffect, useState } from "react";
import { Button, Grid, Label } from "semantic-ui-react";
import PhotoWidgetCropper from "./PhotoWidgetCropper";
import PhotoWidgetDropzone from "./PhotoWidgetDropzone";

interface Props {
	loading: boolean;
	uploadPhoto: (file: Blob) => void;
}

export default function PhotoUploadWidget({ loading, uploadPhoto }: Props) {
	const [files, setFiles] = useState<any>([]);
	const [cropper, setCropper] = useState<Cropper>();

	function onCrop() {
		if (cropper) {
			cropper.getCroppedCanvas().toBlob(blob => uploadPhoto(blob!));
		}
	}

	useEffect(() => {
		return () => {
			files.forEach((file: any) => URL.revokeObjectURL(file.preview))
		}
	}, [files])

	return (
		<Grid>
			<Grid.Column width={4}>
				<Label basic style={{ marginBottom: 4 }}>Змінити фотографію</Label>
				{files && files.length > 0 ?
					<>
						<PhotoWidgetCropper setCropper={setCropper} imagePreview={files[0].preview} />
						<Button.Group widths={2}>
							<Button loading={loading} onClick={onCrop} positive icon='check' />
							<Button disabled={loading} onClick={() => setFiles([])} icon='close' />
						</Button.Group>
					</>
					: <PhotoWidgetDropzone setFiles={setFiles} />
				}
			</Grid.Column>
		</Grid>
	)
}