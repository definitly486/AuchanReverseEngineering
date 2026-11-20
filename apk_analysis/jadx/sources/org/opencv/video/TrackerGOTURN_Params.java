package org.opencv.video;

/* JADX INFO: loaded from: classes3.dex */
public class TrackerGOTURN_Params {
    protected final long nativeObj;

    private static native long TrackerGOTURN_Params_0();

    private static native void delete(long j);

    private static native String get_modelBin_0(long j);

    private static native String get_modelTxt_0(long j);

    private static native void set_modelBin_0(long j, String str);

    private static native void set_modelTxt_0(long j, String str);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
