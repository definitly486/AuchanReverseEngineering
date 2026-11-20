package org.opencv.dnn;

/* JADX INFO: loaded from: classes3.dex */
public class Image2BlobParams {
    protected final long nativeObj;

    private static native long Image2BlobParams_0();

    private static native long Image2BlobParams_1(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9, double d10, boolean z, int i, int i2, double d11, double d12, double d13, double d14);

    private static native long Image2BlobParams_2(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9, double d10, boolean z, int i, int i2);

    private static native long Image2BlobParams_4(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9, double d10, boolean z, int i);

    private static native long Image2BlobParams_5(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9, double d10, boolean z);

    private static native long Image2BlobParams_6(double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, double d9, double d10);

    private static native long Image2BlobParams_7(double d, double d2, double d3, double d4, double d5, double d6);

    private static native long Image2BlobParams_8(double d, double d2, double d3, double d4);

    private static native double[] blobRectToImageRect_0(long j, int i, int i2, int i3, int i4, double d, double d2);

    private static native void blobRectsToImageRects_0(long j, long j2, long j3, double d, double d2);

    private static native void delete(long j);

    private static native double[] get_borderValue_0(long j);

    private static native int get_datalayout_0(long j);

    private static native int get_ddepth_0(long j);

    private static native double[] get_mean_0(long j);

    private static native int get_paddingmode_0(long j);

    private static native double[] get_scalefactor_0(long j);

    private static native double[] get_size_0(long j);

    private static native boolean get_swapRB_0(long j);

    private static native void set_borderValue_0(long j, double d, double d2, double d3, double d4);

    private static native void set_datalayout_0(long j, int i);

    private static native void set_ddepth_0(long j, int i);

    private static native void set_mean_0(long j, double d, double d2, double d3, double d4);

    private static native void set_paddingmode_0(long j, int i);

    private static native void set_scalefactor_0(long j, double d, double d2, double d3, double d4);

    private static native void set_size_0(long j, double d, double d2);

    private static native void set_swapRB_0(long j, boolean z);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
