package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class RefineParameters {
    protected final long nativeObj;

    private static native long RefineParameters_0(float f, float f2, boolean z);

    private static native long RefineParameters_1(float f, float f2);

    private static native long RefineParameters_2(float f);

    private static native long RefineParameters_3();

    private static native void delete(long j);

    private static native boolean get_checkAllOrders_0(long j);

    private static native float get_errorCorrectionRate_0(long j);

    private static native float get_minRepDistance_0(long j);

    private static native void set_checkAllOrders_0(long j, boolean z);

    private static native void set_errorCorrectionRate_0(long j, float f);

    private static native void set_minRepDistance_0(long j, float f);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
