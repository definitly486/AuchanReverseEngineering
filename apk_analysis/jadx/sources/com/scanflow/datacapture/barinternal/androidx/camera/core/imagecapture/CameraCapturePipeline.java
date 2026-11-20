package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import com.google.common.util.concurrent.ListenableFuture;

/* JADX INFO: compiled from: CameraCapturePipeline.kt */
/* JADX INFO: loaded from: classes.dex */
public interface CameraCapturePipeline {
    ListenableFuture invokePostCapture();

    ListenableFuture invokePreCapture();
}
