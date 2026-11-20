package org.opencv.dnn;

/* JADX INFO: loaded from: classes3.dex */
public class ClassificationModel extends Model {
    private static native long ClassificationModel_0(String str, String str2);

    private static native long ClassificationModel_1(String str);

    private static native long ClassificationModel_2(long j);

    private static native void classify_0(long j, long j2, double[] dArr, double[] dArr2);

    private static native void delete(long j);

    private static native boolean getEnableSoftmaxPostProcessing_0(long j);

    private static native long setEnableSoftmaxPostProcessing_0(long j, boolean z);

    @Override // org.opencv.dnn.Model
    protected void finalize() {
        delete(this.nativeObj);
    }
}
