package org.opencv.video;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class SparseOpticalFlow extends Algorithm {
    private static native void calc_0(long j, long j2, long j3, long j4, long j5, long j6, long j7);

    private static native void calc_1(long j, long j2, long j3, long j4, long j5, long j6);

    private static native void delete(long j);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
