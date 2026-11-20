package org.opencv.video;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class BackgroundSubtractor extends Algorithm {
    private static native void apply_0(long j, long j2, long j3, double d);

    private static native void apply_1(long j, long j2, long j3);

    private static native void delete(long j);

    private static native void getBackgroundImage_0(long j, long j2);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
