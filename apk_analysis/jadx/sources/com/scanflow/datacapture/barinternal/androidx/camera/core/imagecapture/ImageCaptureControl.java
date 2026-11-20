package com.scanflow.datacapture.barinternal.androidx.camera.core.imagecapture;

import com.google.common.util.concurrent.ListenableFuture;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public interface ImageCaptureControl {
    void lockFlashMode();

    ListenableFuture submitStillCaptureRequests(List list);

    void unlockFlashMode();
}
