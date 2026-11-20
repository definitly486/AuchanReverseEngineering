package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class FaceDetectorYN {
    protected final long nativeObj;

    private static native long create_0(String str, String str2, double d, double d2, float f, float f2, int i, int i2, int i3);

    private static native long create_1(String str, String str2, double d, double d2, float f, float f2, int i, int i2);

    private static native long create_10(String str, long j, long j2, double d, double d2, float f);

    private static native long create_11(String str, long j, long j2, double d, double d2);

    private static native long create_2(String str, String str2, double d, double d2, float f, float f2, int i);

    private static native long create_3(String str, String str2, double d, double d2, float f, float f2);

    private static native long create_4(String str, String str2, double d, double d2, float f);

    private static native long create_5(String str, String str2, double d, double d2);

    private static native long create_6(String str, long j, long j2, double d, double d2, float f, float f2, int i, int i2, int i3);

    private static native long create_7(String str, long j, long j2, double d, double d2, float f, float f2, int i, int i2);

    private static native long create_8(String str, long j, long j2, double d, double d2, float f, float f2, int i);

    private static native long create_9(String str, long j, long j2, double d, double d2, float f, float f2);

    private static native void delete(long j);

    private static native int detect_0(long j, long j2, long j3);

    private static native double[] getInputSize_0(long j);

    private static native float getNMSThreshold_0(long j);

    private static native float getScoreThreshold_0(long j);

    private static native int getTopK_0(long j);

    private static native void setInputSize_0(long j, double d, double d2);

    private static native void setNMSThreshold_0(long j, float f);

    private static native void setScoreThreshold_0(long j, float f);

    private static native void setTopK_0(long j, int i);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
