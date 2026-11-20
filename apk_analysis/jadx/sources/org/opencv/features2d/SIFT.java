package org.opencv.features2d;

/* JADX INFO: loaded from: classes3.dex */
public class SIFT extends Feature2D {
    private static native long create_0(int i, int i2, double d, double d2, double d3, boolean z);

    private static native long create_1(int i, int i2, double d, double d2, double d3);

    private static native long create_2(int i, int i2, double d, double d2);

    private static native long create_3(int i, int i2, double d);

    private static native long create_4(int i, int i2);

    private static native long create_5(int i);

    private static native long create_6();

    private static native long create_7(int i, int i2, double d, double d2, double d3, int i3, boolean z);

    private static native long create_8(int i, int i2, double d, double d2, double d3, int i3);

    private static native void delete(long j);

    private static native double getContrastThreshold_0(long j);

    private static native String getDefaultName_0(long j);

    private static native double getEdgeThreshold_0(long j);

    private static native int getNFeatures_0(long j);

    private static native int getNOctaveLayers_0(long j);

    private static native double getSigma_0(long j);

    private static native void setContrastThreshold_0(long j, double d);

    private static native void setEdgeThreshold_0(long j, double d);

    private static native void setNFeatures_0(long j, int i);

    private static native void setNOctaveLayers_0(long j, int i);

    private static native void setSigma_0(long j, double d);

    @Override // org.opencv.features2d.Feature2D, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
