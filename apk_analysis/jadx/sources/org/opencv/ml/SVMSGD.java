package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class SVMSGD extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native float getInitialStepSize_0(long j);

    private static native float getMarginRegularization_0(long j);

    private static native int getMarginType_0(long j);

    private static native float getShift_0(long j);

    private static native float getStepDecreasingPower_0(long j);

    private static native int getSvmsgdType_0(long j);

    private static native double[] getTermCriteria_0(long j);

    private static native long getWeights_0(long j);

    private static native long load_0(String str, String str2);

    private static native long load_1(String str);

    private static native void setInitialStepSize_0(long j, float f);

    private static native void setMarginRegularization_0(long j, float f);

    private static native void setMarginType_0(long j, int i);

    private static native void setOptimalParameters_0(long j, int i, int i2);

    private static native void setOptimalParameters_1(long j, int i);

    private static native void setOptimalParameters_2(long j);

    private static native void setStepDecreasingPower_0(long j, float f);

    private static native void setSvmsgdType_0(long j, int i);

    private static native void setTermCriteria_0(long j, int i, int i2, double d);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
