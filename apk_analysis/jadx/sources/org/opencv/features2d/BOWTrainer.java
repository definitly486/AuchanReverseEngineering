package org.opencv.features2d;

/* JADX INFO: loaded from: classes3.dex */
public class BOWTrainer {
    protected final long nativeObj;

    private static native void add_0(long j, long j2);

    private static native void clear_0(long j);

    private static native long cluster_0(long j);

    private static native long cluster_1(long j, long j2);

    private static native void delete(long j);

    private static native int descriptorsCount_0(long j);

    private static native long getDescriptors_0(long j);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
