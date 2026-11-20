package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class Boost extends DTrees {
    private static native long create_0();

    private static native void delete(long j);

    private static native int getBoostType_0(long j);

    private static native int getWeakCount_0(long j);

    private static native double getWeightTrimRate_0(long j);

    private static native long load_0(String str, String str2);

    private static native long load_1(String str);

    private static native void setBoostType_0(long j, int i);

    private static native void setWeakCount_0(long j, int i);

    private static native void setWeightTrimRate_0(long j, double d);

    @Override // org.opencv.ml.DTrees, org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
