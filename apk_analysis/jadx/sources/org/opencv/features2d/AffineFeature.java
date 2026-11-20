package org.opencv.features2d;

/* JADX INFO: loaded from: classes3.dex */
public class AffineFeature extends Feature2D {
    private static native long create_0(long j, int i, int i2, float f, float f2);

    private static native long create_1(long j, int i, int i2, float f);

    private static native long create_2(long j, int i, int i2);

    private static native long create_3(long j, int i);

    private static native long create_4(long j);

    private static native void delete(long j);

    private static native String getDefaultName_0(long j);

    private static native void getViewParams_0(long j, long j2, long j3);

    private static native void setViewParams_0(long j, long j2, long j3);

    @Override // org.opencv.features2d.Feature2D, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
