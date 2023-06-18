import React, { useCallback } from 'react'
import { useDropzone } from 'react-dropzone'
import { Header, Icon } from 'semantic-ui-react';

interface Props {
	setFiles: (files: any) => void;
	style?: any;
	headerContent?: string;
}


export default function PhotoWidgetDropzone({ setFiles, style, headerContent }: Props) {
	const dzStyles = style ? style : {
		border: 'dashed 3px #eee',
		borderColor: '#eee',
		borderRadius: '5px',
		paddingTop: '50px',
		textAlign: 'center' as 'center',
		height: 200
	}

	const dzActive = {
		borderColor: 'green'
	}

	const onDrop = useCallback((acceptedFiles: any) => {
		setFiles(acceptedFiles.map((file: any) => Object.assign(file, {
			preview: URL.createObjectURL(file)
		})))
	}, [setFiles])
	const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop })

	return (
		<div {...getRootProps()} style={isDragActive ? { ...dzStyles, ...dzActive } : dzStyles}>
			<input {...getInputProps()} />
			<Icon name='plus' size='huge' />
			<Header content={headerContent || 'Додати фотографію'} style={{ marginTop: 15 }} />
		</div>
	)
}