package org.opencv.photo;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class Tonemap extends Algorithm {
    private static native void delete(long j);

    private static native float getGamma_0(long j);

    private static native void process_0(long j, long j2, long j3);

    private static native void setGamma_0(long j, float f);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
