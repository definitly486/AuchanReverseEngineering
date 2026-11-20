package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class SVM extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native double getC_0(long j);

    private static native long getClassWeights_0(long j);

    private static native double getCoef0_0(long j);

    private static native double getDecisionFunction_0(long j, int i, long j2, long j3);

    private static native long getDefaultGridPtr_0(int i);

    private static native double getDegree_0(long j);

    private static native double getGamma_0(long j);

    private static native int getKernelType_0(long j);

    private static native double getNu_0(long j);

    private static native double getP_0(long j);

    private static native long getSupportVectors_0(long j);

    private static native double[] getTermCriteria_0(long j);

    private static native int getType_0(long j);

    private static native long getUncompressedSupportVectors_0(long j);

    private static native long load_0(String str);

    private static native void setC_0(long j, double d);

    private static native void setClassWeights_0(long j, long j2);

    private static native void setCoef0_0(long j, double d);

    private static native void setDegree_0(long j, double d);

    private static native void setGamma_0(long j, double d);

    private static native void setKernel_0(long j, int i);

    private static native void setNu_0(long j, double d);

    private static native void setP_0(long j, double d);

    private static native void setTermCriteria_0(long j, int i, int i2, double d);

    private static native void setType_0(long j, int i);

    private static native boolean trainAuto_0(long j, long j2, int i, long j3, int i2, long j4, long j5, long j6, long j7, long j8, long j9, boolean z);

    private static native boolean trainAuto_1(long j, long j2, int i, long j3, int i2, long j4, long j5, long j6, long j7, long j8, long j9);

    private static native boolean trainAuto_2(long j, long j2, int i, long j3, int i2, long j4, long j5, long j6, long j7, long j8);

    private static native boolean trainAuto_3(long j, long j2, int i, long j3, int i2, long j4, long j5, long j6, long j7);

    private static native boolean trainAuto_4(long j, long j2, int i, long j3, int i2, long j4, long j5, long j6);

    private static native boolean trainAuto_5(long j, long j2, int i, long j3, int i2, long j4, long j5);

    private static native boolean trainAuto_6(long j, long j2, int i, long j3, int i2, long j4);

    private static native boolean trainAuto_7(long j, long j2, int i, long j3, int i2);

    private static native boolean trainAuto_8(long j, long j2, int i, long j3);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
