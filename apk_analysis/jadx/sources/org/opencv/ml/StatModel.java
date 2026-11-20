package org.opencv.ml;

import org.opencv.core.Algorithm;

/* JADX INFO: loaded from: classes3.dex */
public class StatModel extends Algorithm {
    private static native float calcError_0(long j, long j2, boolean z, long j3);

    private static native void delete(long j);

    private static native boolean empty_0(long j);

    private static native int getVarCount_0(long j);

    private static native boolean isClassifier_0(long j);

    private static native boolean isTrained_0(long j);

    private static native float predict_0(long j, long j2, long j3, int i);

    private static native float predict_1(long j, long j2, long j3);

    private static native float predict_2(long j, long j2);

    private static native boolean train_0(long j, long j2, int i);

    private static native boolean train_1(long j, long j2);

    private static native boolean train_2(long j, long j2, int i, long j3);

    @Override // org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
