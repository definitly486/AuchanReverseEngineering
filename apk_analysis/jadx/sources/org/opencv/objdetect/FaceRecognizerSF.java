package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class FaceRecognizerSF {
    protected final long nativeObj;

    private static native void alignCrop_0(long j, long j2, long j3, long j4);

    private static native long create_0(String str, String str2, int i, int i2);

    private static native long create_1(String str, String str2, int i);

    private static native long create_2(String str, String str2);

    private static native long create_3(String str, long j, long j2, int i, int i2);

    private static native long create_4(String str, long j, long j2, int i);

    private static native long create_5(String str, long j, long j2);

    private static native void delete(long j);

    private static native void feature_0(long j, long j2, long j3);

    private static native double match_0(long j, long j2, long j3, int i);

    private static native double match_1(long j, long j2, long j3);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
