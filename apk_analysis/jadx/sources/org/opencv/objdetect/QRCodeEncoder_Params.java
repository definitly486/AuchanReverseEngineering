package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class QRCodeEncoder_Params {
    protected final long nativeObj;

    private static native long QRCodeEncoder_Params_0();

    private static native void delete(long j);

    private static native int get_correction_level_0(long j);

    private static native int get_mode_0(long j);

    private static native int get_structure_number_0(long j);

    private static native int get_version_0(long j);

    private static native void set_correction_level_0(long j, int i);

    private static native void set_mode_0(long j, int i);

    private static native void set_structure_number_0(long j, int i);

    private static native void set_version_0(long j, int i);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
