package org.opencv.photo;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class CalibrateCRF extends Algorithm {
    private static native void delete(long j);

    private static native void process_0(long j, long j2, long j3, long j4);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
