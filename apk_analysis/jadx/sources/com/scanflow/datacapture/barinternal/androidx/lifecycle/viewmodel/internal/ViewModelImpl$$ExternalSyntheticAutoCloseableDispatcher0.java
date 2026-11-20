package com.scanflow.datacapture.barinternal.androidx.lifecycle.viewmodel.internal;

import android.content.res.TypedArray;
import android.media.MediaDrm;
import android.media.MediaMetadataRetriever;
import androidx.camera.core.impl.utils.executor.HandlerScheduledExecutorService$$ExternalSyntheticAutoCloseableForwarder0;
import java.util.concurrent.ExecutorService;

/* JADX INFO: compiled from: R8$$SyntheticClass */
/* JADX INFO: loaded from: classes.dex */
public abstract /* synthetic */ class ViewModelImpl$$ExternalSyntheticAutoCloseableDispatcher0 {
    public static /* synthetic */ void m(Object obj) throws Exception {
        if (obj instanceof AutoCloseable) {
            ((AutoCloseable) obj).close();
            return;
        }
        if (obj instanceof ExecutorService) {
            HandlerScheduledExecutorService$$ExternalSyntheticAutoCloseableForwarder0.m((ExecutorService) obj);
            return;
        }
        if (obj instanceof TypedArray) {
            ((TypedArray) obj).recycle();
            return;
        }
        if (obj instanceof MediaMetadataRetriever) {
            ((MediaMetadataRetriever) obj).release();
        } else if (obj instanceof MediaDrm) {
            ((MediaDrm) obj).release();
        } else {
            ViewModelImpl$$ExternalSyntheticThrowIAE1.m(obj);
        }
    }
}
