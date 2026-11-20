package org.opencv.imgcodecs;

/* JADX INFO: loaded from: classes3.dex */
public class Animation {
    protected final long nativeObj;

    private static native long Animation_0(int i, double d, double d2, double d3, double d4);

    private static native long Animation_1(int i);

    private static native long Animation_2();

    private static native void delete(long j);

    private static native double[] get_bgcolor_0(long j);

    private static native long get_durations_0(long j);

    private static native long get_frames_0(long j);

    private static native int get_loop_count_0(long j);

    private static native long get_still_image_0(long j);

    private static native void set_bgcolor_0(long j, double d, double d2, double d3, double d4);

    private static native void set_durations_0(long j, long j2);

    private static native void set_frames_0(long j, long j2);

    private static native void set_loop_count_0(long j, int i);

    private static native void set_still_image_0(long j, long j2);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
