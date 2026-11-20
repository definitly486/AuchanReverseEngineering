package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import com.google.common.util.concurrent.ListenableFuture;
import java.nio.ByteBuffer;

/* JADX INFO: loaded from: classes.dex */
public interface InputBuffer {
    boolean cancel();

    ByteBuffer getByteBuffer();

    ListenableFuture getTerminationFuture();

    void setEndOfStream(boolean z);

    void setPresentationTimeUs(long j);

    boolean submit();
}
