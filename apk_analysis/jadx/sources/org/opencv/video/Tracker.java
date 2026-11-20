package org.opencv.video;

/* JADX INFO: loaded from: classes3.dex */
public class Tracker {
    protected final long nativeObj;

    private static native void delete(long j);

    private static native void init_0(long j, long j2, int i, int i2, int i3, int i4);

    private static native boolean update_0(long j, long j2, double[] dArr);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
