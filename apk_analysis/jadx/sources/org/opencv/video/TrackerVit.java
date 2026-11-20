package org.opencv.video;

/* JADX INFO: loaded from: classes3.dex */
public class TrackerVit extends Tracker {
    private static native long create_0(long j);

    private static native long create_1();

    private static native long create_2(long j, double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8, float f);

    private static native long create_3(long j, double d, double d2, double d3, double d4, double d5, double d6, double d7, double d8);

    private static native long create_4(long j, double d, double d2, double d3, double d4);

    private static native long create_5(long j);

    private static native void delete(long j);

    private static native float getTrackingScore_0(long j);

    @Override // org.opencv.video.Tracker
    protected void finalize() {
        delete(this.nativeObj);
    }
}
