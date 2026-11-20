package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class ANN_MLP extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native double getAnnealCoolingRatio_0(long j);

    private static native double getAnnealFinalT_0(long j);

    private static native double getAnnealInitialT_0(long j);

    private static native int getAnnealItePerStep_0(long j);

    private static native double getBackpropMomentumScale_0(long j);

    private static native double getBackpropWeightScale_0(long j);

    private static native long getLayerSizes_0(long j);

    private static native double getRpropDW0_0(long j);

    private static native double getRpropDWMax_0(long j);

    private static native double getRpropDWMin_0(long j);

    private static native double getRpropDWMinus_0(long j);

    private static native double getRpropDWPlus_0(long j);

    private static native double[] getTermCriteria_0(long j);

    private static native int getTrainMethod_0(long j);

    private static native long getWeights_0(long j, int i);

    private static native long load_0(String str);

    private static native void setActivationFunction_0(long j, int i, double d, double d2);

    private static native void setActivationFunction_1(long j, int i, double d);

    private static native void setActivationFunction_2(long j, int i);

    private static native void setAnnealCoolingRatio_0(long j, double d);

    private static native void setAnnealFinalT_0(long j, double d);

    private static native void setAnnealInitialT_0(long j, double d);

    private static native void setAnnealItePerStep_0(long j, int i);

    private static native void setBackpropMomentumScale_0(long j, double d);

    private static native void setBackpropWeightScale_0(long j, double d);

    private static native void setLayerSizes_0(long j, long j2);

    private static native void setRpropDW0_0(long j, double d);

    private static native void setRpropDWMax_0(long j, double d);

    private static native void setRpropDWMin_0(long j, double d);

    private static native void setRpropDWMinus_0(long j, double d);

    private static native void setRpropDWPlus_0(long j, double d);

    private static native void setTermCriteria_0(long j, int i, int i2, double d);

    private static native void setTrainMethod_0(long j, int i, double d, double d2);

    private static native void setTrainMethod_1(long j, int i, double d);

    private static native void setTrainMethod_2(long j, int i);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
