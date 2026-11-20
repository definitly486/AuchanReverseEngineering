package org.opencv.core;

/* JADX INFO: loaded from: classes3.dex */
public class TickMeter {
    protected final long nativeObj;

    private static native long TickMeter_0();

    private static native void delete(long j);

    private static native double getAvgTimeMilli_0(long j);

    private static native double getAvgTimeSec_0(long j);

    private static native long getCounter_0(long j);

    private static native double getFPS_0(long j);

    private static native double getLastTimeMicro_0(long j);

    private static native double getLastTimeMilli_0(long j);

    private static native double getLastTimeSec_0(long j);

    private static native long getLastTimeTicks_0(long j);

    private static native double getTimeMicro_0(long j);

    private static native double getTimeMilli_0(long j);

    private static native double getTimeSec_0(long j);

    private static native long getTimeTicks_0(long j);

    private static native void reset_0(long j);

    private static native void start_0(long j);

    private static native void stop_0(long j);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
