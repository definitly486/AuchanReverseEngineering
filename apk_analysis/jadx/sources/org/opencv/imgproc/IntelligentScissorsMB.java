package org.opencv.imgproc;

/* JADX INFO: loaded from: classes3.dex */
public class IntelligentScissorsMB {
    protected final long nativeObj;

    private static native long IntelligentScissorsMB_0();

    private static native long applyImageFeatures_0(long j, long j2, long j3, long j4, long j5);

    private static native long applyImageFeatures_1(long j, long j2, long j3, long j4);

    private static native long applyImage_0(long j, long j2);

    private static native void buildMap_0(long j, double d, double d2);

    private static native void delete(long j);

    private static native void getContour_0(long j, double d, double d2, long j2, boolean z);

    private static native void getContour_1(long j, double d, double d2, long j2);

    private static native long setEdgeFeatureCannyParameters_0(long j, double d, double d2, int i, boolean z);

    private static native long setEdgeFeatureCannyParameters_1(long j, double d, double d2, int i);

    private static native long setEdgeFeatureCannyParameters_2(long j, double d, double d2);

    private static native long setEdgeFeatureZeroCrossingParameters_0(long j, float f);

    private static native long setEdgeFeatureZeroCrossingParameters_1(long j);

    private static native long setGradientMagnitudeMaxLimit_0(long j, float f);

    private static native long setGradientMagnitudeMaxLimit_1(long j);

    private static native long setWeights_0(long j, float f, float f2, float f3);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
