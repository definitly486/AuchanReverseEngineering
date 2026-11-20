package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class LogisticRegression extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native int getIterations_0(long j);

    private static native double getLearningRate_0(long j);

    private static native int getMiniBatchSize_0(long j);

    private static native int getRegularization_0(long j);

    private static native double[] getTermCriteria_0(long j);

    private static native int getTrainMethod_0(long j);

    private static native long get_learnt_thetas_0(long j);

    private static native long load_0(String str, String str2);

    private static native long load_1(String str);

    private static native float predict_0(long j, long j2, long j3, int i);

    private static native float predict_1(long j, long j2, long j3);

    private static native float predict_2(long j, long j2);

    private static native void setIterations_0(long j, int i);

    private static native void setLearningRate_0(long j, double d);

    private static native void setMiniBatchSize_0(long j, int i);

    private static native void setRegularization_0(long j, int i);

    private static native void setTermCriteria_0(long j, int i, int i2, double d);

    private static native void setTrainMethod_0(long j, int i);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
