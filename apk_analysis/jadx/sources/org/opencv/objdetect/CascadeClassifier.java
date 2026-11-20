package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class CascadeClassifier {
    protected final long nativeObj;

    private static native long CascadeClassifier_0();

    private static native long CascadeClassifier_1(String str);

    private static native boolean convert_0(String str, String str2);

    private static native void delete(long j);

    private static native void detectMultiScale2_0(long j, long j2, long j3, long j4, double d, int i, int i2, double d2, double d3, double d4, double d5);

    private static native void detectMultiScale2_1(long j, long j2, long j3, long j4, double d, int i, int i2, double d2, double d3);

    private static native void detectMultiScale2_2(long j, long j2, long j3, long j4, double d, int i, int i2);

    private static native void detectMultiScale2_3(long j, long j2, long j3, long j4, double d, int i);

    private static native void detectMultiScale2_4(long j, long j2, long j3, long j4, double d);

    private static native void detectMultiScale2_5(long j, long j2, long j3, long j4);

    private static native void detectMultiScale3_0(long j, long j2, long j3, long j4, long j5, double d, int i, int i2, double d2, double d3, double d4, double d5, boolean z);

    private static native void detectMultiScale3_1(long j, long j2, long j3, long j4, long j5, double d, int i, int i2, double d2, double d3, double d4, double d5);

    private static native void detectMultiScale3_2(long j, long j2, long j3, long j4, long j5, double d, int i, int i2, double d2, double d3);

    private static native void detectMultiScale3_3(long j, long j2, long j3, long j4, long j5, double d, int i, int i2);

    private static native void detectMultiScale3_4(long j, long j2, long j3, long j4, long j5, double d, int i);

    private static native void detectMultiScale3_5(long j, long j2, long j3, long j4, long j5, double d);

    private static native void detectMultiScale3_6(long j, long j2, long j3, long j4, long j5);

    private static native void detectMultiScale_0(long j, long j2, long j3, double d, int i, int i2, double d2, double d3, double d4, double d5);

    private static native void detectMultiScale_1(long j, long j2, long j3, double d, int i, int i2, double d2, double d3);

    private static native void detectMultiScale_2(long j, long j2, long j3, double d, int i, int i2);

    private static native void detectMultiScale_3(long j, long j2, long j3, double d, int i);

    private static native void detectMultiScale_4(long j, long j2, long j3, double d);

    private static native void detectMultiScale_5(long j, long j2, long j3);

    private static native boolean empty_0(long j);

    private static native int getFeatureType_0(long j);

    private static native double[] getOriginalWindowSize_0(long j);

    private static native boolean isOldFormatCascade_0(long j);

    private static native boolean load_0(long j, String str);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
