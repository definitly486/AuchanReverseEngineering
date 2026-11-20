package org.opencv.videoio;

/* JADX INFO: loaded from: classes3.dex */
public class VideoCapture {
    protected final long nativeObj;

    private static native long VideoCapture_0();

    private static native long VideoCapture_1(String str, int i);

    private static native long VideoCapture_2(String str);

    private static native long VideoCapture_3(String str, int i, long j);

    private static native long VideoCapture_4(int i, int i2);

    private static native long VideoCapture_5(int i);

    private static native long VideoCapture_6(int i, int i2, long j);

    private static native long VideoCapture_7(IStreamReader iStreamReader, int i, long j);

    private static native void delete(long j);

    private static native String getBackendName_0(long j);

    private static native boolean getExceptionMode_0(long j);

    private static native double get_0(long j, int i);

    private static native boolean grab_0(long j);

    private static native boolean isOpened_0(long j);

    private static native boolean open_0(long j, String str, int i);

    private static native boolean open_1(long j, String str);

    private static native boolean open_2(long j, String str, int i, long j2);

    private static native boolean open_3(long j, int i, int i2);

    private static native boolean open_4(long j, int i);

    private static native boolean open_5(long j, int i, int i2, long j2);

    private static native boolean open_6(long j, IStreamReader iStreamReader, int i, long j2);

    private static native boolean read_0(long j, long j2);

    private static native void release_0(long j);

    private static native boolean retrieve_0(long j, long j2, int i);

    private static native boolean retrieve_1(long j, long j2);

    private static native void setExceptionMode_0(long j, boolean z);

    private static native boolean set_0(long j, int i, double d);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
