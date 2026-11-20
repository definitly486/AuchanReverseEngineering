package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class NormalBayesClassifier extends StatModel {
    private static native long create_0();

    private static native void delete(long j);

    private static native long load_0(String str, String str2);

    private static native long load_1(String str);

    private static native float predictProb_0(long j, long j2, long j3, long j4, int i);

    private static native float predictProb_1(long j, long j2, long j3, long j4);

    @Override // org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
