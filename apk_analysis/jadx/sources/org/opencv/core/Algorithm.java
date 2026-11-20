package org.opencv.core;

/* JADX INFO: loaded from: classes3.dex */
public class Algorithm {
    protected final long nativeObj;

    private static native void clear_0(long j);

    private static native void delete(long j);

    private static native boolean empty_0(long j);

    private static native String getDefaultName_0(long j);

    private static native void save_0(long j, String str);

    protected Algorithm(long j) {
        this.nativeObj = j;
    }

    protected void finalize() {
        delete(this.nativeObj);
    }
}
