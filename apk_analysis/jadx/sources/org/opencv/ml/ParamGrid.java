package org.opencv.ml;

/* JADX INFO: loaded from: classes3.dex */
public class ParamGrid {
    protected final long nativeObj;

    private static native long create_0(double d, double d2, double d3);

    private static native long create_1(double d, double d2);

    private static native long create_2(double d);

    private static native long create_3();

    private static native void delete(long j);

    private static native double get_logStep_0(long j);

    private static native double get_maxVal_0(long j);

    private static native double get_minVal_0(long j);

    private static native void set_logStep_0(long j, double d);

    private static native void set_maxVal_0(long j, double d);

    private static native void set_minVal_0(long j, double d);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
