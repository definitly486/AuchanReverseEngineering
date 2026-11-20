package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class EM extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native int getClustersNumber_0(long j);

    private static native int getCovarianceMatrixType_0(long j);

    private static native void getCovs_0(long j, long j2);

    private static native long getMeans_0(long j);

    private static native double[] getTermCriteria_0(long j);

    private static native long getWeights_0(long j);

    private static native long load_0(String str, String str2);

    private static native long load_1(String str);

    private static native double[] predict2_0(long j, long j2, long j3);

    private static native float predict_0(long j, long j2, long j3, int i);

    private static native float predict_1(long j, long j2, long j3);

    private static native float predict_2(long j, long j2);

    private static native void setClustersNumber_0(long j, int i);

    private static native void setCovarianceMatrixType_0(long j, int i);

    private static native void setTermCriteria_0(long j, int i, int i2, double d);

    private static native boolean trainEM_0(long j, long j2, long j3, long j4, long j5);

    private static native boolean trainEM_1(long j, long j2, long j3, long j4);

    private static native boolean trainEM_2(long j, long j2, long j3);

    private static native boolean trainEM_3(long j, long j2);

    private static native boolean trainE_0(long j, long j2, long j3, long j4, long j5, long j6, long j7, long j8);

    private static native boolean trainE_1(long j, long j2, long j3, long j4, long j5, long j6, long j7);

    private static native boolean trainE_2(long j, long j2, long j3, long j4, long j5, long j6);

    private static native boolean trainE_3(long j, long j2, long j3, long j4, long j5);

    private static native boolean trainE_4(long j, long j2, long j3, long j4);

    private static native boolean trainE_5(long j, long j2, long j3);

    private static native boolean trainM_0(long j, long j2, long j3, long j4, long j5, long j6);

    private static native boolean trainM_1(long j, long j2, long j3, long j4, long j5);

    private static native boolean trainM_2(long j, long j2, long j3, long j4);

    private static native boolean trainM_3(long j, long j2, long j3);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
