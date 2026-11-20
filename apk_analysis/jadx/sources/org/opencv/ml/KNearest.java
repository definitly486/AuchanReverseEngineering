package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class KNearest extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native float findNearest_0(long j, long j2, int i, long j3, long j4, long j5);

    private static native float findNearest_1(long j, long j2, int i, long j3, long j4);

    private static native float findNearest_2(long j, long j2, int i, long j3);

    private static native int getAlgorithmType_0(long j);

    private static native int getDefaultK_0(long j);

    private static native int getEmax_0(long j);

    private static native boolean getIsClassifier_0(long j);

    private static native long load_0(String str);

    private static native void setAlgorithmType_0(long j, int i);

    private static native void setDefaultK_0(long j, int i);

    private static native void setEmax_0(long j, int i);

    private static native void setIsClassifier_0(long j, boolean z);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
