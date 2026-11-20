package org.opencv.video;

/* JADX INFO: loaded from: classes3.dex */
public class TrackerDaSiamRPN_Params {
    protected final long nativeObj;

    private static native long TrackerDaSiamRPN_Params_0();

    private static native void delete(long j);

    private static native int get_backend_0(long j);

    private static native String get_kernel_cls1_0(long j);

    private static native String get_kernel_r1_0(long j);

    private static native String get_model_0(long j);

    private static native int get_target_0(long j);

    private static native void set_backend_0(long j, int i);

    private static native void set_kernel_cls1_0(long j, String str);

    private static native void set_kernel_r1_0(long j, String str);

    private static native void set_model_0(long j, String str);

    private static native void set_target_0(long j, int i);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
