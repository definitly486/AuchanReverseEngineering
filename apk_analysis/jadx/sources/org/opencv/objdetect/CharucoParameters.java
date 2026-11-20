package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class CharucoParameters {
    protected final long nativeObj;

    private static native long CharucoParameters_0();

    private static native void delete(long j);

    private static native long get_cameraMatrix_0(long j);

    private static native boolean get_checkMarkers_0(long j);

    private static native long get_distCoeffs_0(long j);

    private static native int get_minMarkers_0(long j);

    private static native boolean get_tryRefineMarkers_0(long j);

    private static native void set_cameraMatrix_0(long j, long j2);

    private static native void set_checkMarkers_0(long j, boolean z);

    private static native void set_distCoeffs_0(long j, long j2);

    private static native void set_minMarkers_0(long j, int i);

    private static native void set_tryRefineMarkers_0(long j, boolean z);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
