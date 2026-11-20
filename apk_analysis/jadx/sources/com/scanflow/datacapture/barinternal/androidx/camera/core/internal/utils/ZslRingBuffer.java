package com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils;

import androidx.camera.core.ImageInfo;
import androidx.camera.core.ImageProxy;
import androidx.camera.core.impl.CameraCaptureMetaData;
import androidx.camera.core.impl.CameraCaptureResult;
import androidx.camera.core.impl.CameraCaptureResults;

/* JADX INFO: loaded from: classes.dex */
public final class ZslRingBuffer extends ArrayRingBuffer {
    public ZslRingBuffer(int i, RingBuffer.OnRemoveCallback onRemoveCallback) {
        super(i, onRemoveCallback);
    }

    @Override // com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils.ArrayRingBuffer, com.scanflow.datacapture.barinternal.androidx.camera.core.internal.utils.RingBuffer
    public void enqueue(ImageProxy imageProxy) {
        if (isValidZslFrame(imageProxy.getImageInfo())) {
            super.enqueue((Object) imageProxy);
        } else {
            this.mOnRemoveCallback.onRemove(imageProxy);
        }
    }

    private boolean isValidZslFrame(ImageInfo imageInfo) {
        CameraCaptureResult cameraCaptureResultRetrieveCameraCaptureResult = CameraCaptureResults.retrieveCameraCaptureResult(imageInfo);
        return (cameraCaptureResultRetrieveCameraCaptureResult.getAfState() == CameraCaptureMetaData.AfState.LOCKED_FOCUSED || cameraCaptureResultRetrieveCameraCaptureResult.getAfState() == CameraCaptureMetaData.AfState.PASSIVE_FOCUSED) && cameraCaptureResultRetrieveCameraCaptureResult.getAeState() == CameraCaptureMetaData.AeState.CONVERGED && cameraCaptureResultRetrieveCameraCaptureResult.getAwbState() == CameraCaptureMetaData.AwbState.CONVERGED;
    }
}
