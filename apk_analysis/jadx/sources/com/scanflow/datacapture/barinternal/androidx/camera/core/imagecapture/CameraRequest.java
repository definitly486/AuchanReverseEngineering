package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public final class CameraRequest {
    private final TakePictureCallback mCallback;
    private final List mCaptureConfigs;

    public CameraRequest(List list, TakePictureCallback takePictureCallback) {
        this.mCaptureConfigs = list;
        this.mCallback = takePictureCallback;
    }

    List getCaptureConfigs() {
        return this.mCaptureConfigs;
    }

    boolean isAborted() {
        return this.mCallback.isAborted();
    }
}
