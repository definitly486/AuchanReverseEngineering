package com.google.mediapipe.framework;

/* JADX INFO: loaded from: classes3.dex */
public interface GlSyncToken {
    long nativeToken();

    void release();

    void waitOnCpu();

    void waitOnGpu();
}
