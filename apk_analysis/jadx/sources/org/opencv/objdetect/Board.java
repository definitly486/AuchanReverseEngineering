package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class Board {
    protected final long nativeObj;

    private static native long Board_0(long j, long j2, long j3);

    private static native void delete(long j);

    private static native void generateImage_0(long j, double d, double d2, long j2, int i, int i2);

    private static native void generateImage_1(long j, double d, double d2, long j2, int i);

    private static native void generateImage_2(long j, double d, double d2, long j2);

    private static native long getDictionary_0(long j);

    private static native long getIds_0(long j);

    private static native long getObjPoints_0(long j);

    private static native double[] getRightBottomCorner_0(long j);

    private static native void matchImagePoints_0(long j, long j2, long j3, long j4, long j5);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
