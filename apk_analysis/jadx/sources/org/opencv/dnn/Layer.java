package org.opencv.dnn;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class Layer extends Algorithm {
    private static native void delete(long j);

    private static native void finalize_0(long j, long j2, long j3);

    private static native long get_blobs_0(long j);

    private static native String get_name_0(long j);

    private static native int get_preferableTarget_0(long j);

    private static native String get_type_0(long j);

    private static native int outputNameToIndex_0(long j, String str);

    private static native void run_0(long j, long j2, long j3, long j4);

    private static native void set_blobs_0(long j, long j2);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
