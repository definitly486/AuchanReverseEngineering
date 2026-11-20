package org.opencv.videoio;

/* JADX INFO: loaded from: classes3.dex */
public class VideoWriter {
    protected final long nativeObj;

    private static native long VideoWriter_0();

    private static native long VideoWriter_1(String str, int i, double d, double d2, double d3, boolean z);

    private static native long VideoWriter_2(String str, int i, double d, double d2, double d3);

    private static native long VideoWriter_3(String str, int i, int i2, double d, double d2, double d3, boolean z);

    private static native long VideoWriter_4(String str, int i, int i2, double d, double d2, double d3);

    private static native long VideoWriter_5(String str, int i, double d, double d2, double d3, long j);

    private static native long VideoWriter_6(String str, int i, int i2, double d, double d2, double d3, long j);

    private static native void delete(long j);

    private static native int fourcc_0(char c, char c2, char c3, char c4);

    private static native String getBackendName_0(long j);

    private static native double get_0(long j, int i);

    private static native boolean isOpened_0(long j);

    private static native boolean open_0(long j, String str, int i, double d, double d2, double d3, boolean z);

    private static native boolean open_1(long j, String str, int i, double d, double d2, double d3);

    private static native boolean open_2(long j, String str, int i, int i2, double d, double d2, double d3, boolean z);

    private static native boolean open_3(long j, String str, int i, int i2, double d, double d2, double d3);

    private static native boolean open_4(long j, String str, int i, double d, double d2, double d3, long j2);

    private static native boolean open_5(long j, String str, int i, int i2, double d, double d2, double d3, long j2);

    private static native void release_0(long j);

    private static native boolean set_0(long j, int i, double d);

    private static native void write_0(long j, long j2);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
