package com.scanflow.datacapture.barinternal.androidx.camera.video.internal;

import androidx.camera.core.impl.Observable;
import com.google.common.util.concurrent.ListenableFuture;

/* JADX INFO: loaded from: classes.dex */
public interface BufferProvider extends Observable {

    public enum State {
        ACTIVE,
        INACTIVE
    }

    ListenableFuture acquireBuffer();
}
