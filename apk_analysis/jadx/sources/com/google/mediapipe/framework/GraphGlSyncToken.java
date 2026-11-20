package com.google.mediapipe.framework;

/* JADX INFO: loaded from: classes3.dex */
public final class GraphGlSyncToken implements GlSyncToken {
    private long token;

    private static native void nativeRelease(long j);

    private static native void nativeWaitOnCpu(long j);

    private static native void nativeWaitOnGpu(long j);

    @Override // com.google.mediapipe.framework.GlSyncToken
    public void waitOnCpu() {
        long j = this.token;
        if (j != 0) {
            nativeWaitOnCpu(j);
        }
    }

    @Override // com.google.mediapipe.framework.GlSyncToken
    public void waitOnGpu() {
        long j = this.token;
        if (j != 0) {
            nativeWaitOnGpu(j);
        }
    }

    @Override // com.google.mediapipe.framework.GlSyncToken
    public void release() {
        long j = this.token;
        if (j != 0) {
            nativeRelease(j);
            this.token = 0L;
        }
    }

    @Override // com.google.mediapipe.framework.GlSyncToken
    public long nativeToken() {
        return this.token;
    }

    public GraphGlSyncToken(long j) {
        this.token = j;
    }
}
