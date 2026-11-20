package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class RTrees extends DTrees {
    private static native long create_0();

    private static native void delete(long j);

    private static native int getActiveVarCount_0(long j);

    private static native boolean getCalculateVarImportance_0(long j);

    private static native double getOOBError_0(long j);

    private static native double[] getTermCriteria_0(long j);

    private static native long getVarImportance_0(long j);

    private static native void getVotes_0(long j, long j2, long j3, int i);

    private static native long load_0(String str, String str2);

    private static native long load_1(String str);

    private static native void setActiveVarCount_0(long j, int i);

    private static native void setCalculateVarImportance_0(long j, boolean z);

    private static native void setTermCriteria_0(long j, int i, int i2, double d);

    @Override // org.opencv.ml.DTrees, org.opencv.ml.StatModel, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
