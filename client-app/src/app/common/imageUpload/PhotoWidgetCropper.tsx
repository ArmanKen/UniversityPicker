import React from "react";
import { Cropper } from "react-cropper";
import 'cropperjs/dist/cropper.css'

interface Props {
	imagePreview: string;
	setCropper: (cropper: Cropper) => void;
	style?: any;
}

export default function PhotoWidgetCropper({ imagePreview, setCropper, style }: Props) {
	const defaultStyle = {
		height: 200,
		width: '100%'
	}

	return (
		<Cropper
			minCanvasHeight={150}
			minCanvasWidth={150}
			src={imagePreview}
			style={style || defaultStyle}
			initialAspectRatio={1}
			aspectRatio={1}
			preview='.img-preview'
			guides={false}
			viewMode={1}
			autoCropArea={1}
			background={false}
			onInitialized={cropper => setCropper(cropper)}
		/>
	)
}