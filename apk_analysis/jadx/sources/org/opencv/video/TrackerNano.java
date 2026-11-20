package org.opencv.video;

/* JADX INFO: loaded from: classes3.dex */
public class TrackerNano extends Tracker {
    private static native long create_0(long j);

    private static native long create_1();

    private static native long create_2(long j, long j2);

    private static native void delete(long j);

    private static native float getTrackingScore_0(long j);

    @Override // org.opencv.video.Tracker
    protected void finalize() {
        delete(this.nativeObj);
    }
}
