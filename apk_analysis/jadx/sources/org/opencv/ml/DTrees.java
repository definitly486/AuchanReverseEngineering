package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class DTrees extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native int getCVFolds_0(long j);

    private static native int getMaxCategories_0(long j);

    private static native int getMaxDepth_0(long j);

    private static native int getMinSampleCount_0(long j);

    private static native long getPriors_0(long j);

    private static native float getRegressionAccuracy_0(long j);

    private static native boolean getTruncatePrunedTree_0(long j);

    private static native boolean getUse1SERule_0(long j);

    private static native boolean getUseSurrogates_0(long j);

    private static native long load_0(String str, String str2);

    private static native long load_1(String str);

    private static native void setCVFolds_0(long j, int i);

    private static native void setMaxCategories_0(long j, int i);

    private static native void setMaxDepth_0(long j, int i);

    private static native void setMinSampleCount_0(long j, int i);

    private static native void setPriors_0(long j, long j2);

    private static native void setRegressionAccuracy_0(long j, float f);

    private static native void setTruncatePrunedTree_0(long j, boolean z);

    private static native void setUse1SERule_0(long j, boolean z);

    private static native void setUseSurrogates_0(long j, boolean z);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
