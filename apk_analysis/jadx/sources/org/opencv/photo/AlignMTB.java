package org.opencv.photo;

/* JADX INFO: loaded from: classes3.dex */
public class AlignMTB extends AlignExposures {
    private static native double[] calculateShift_0(long j, long j2, long j3);

    private static native void computeBitmaps_0(long j, long j2, long j3, long j4);

    private static native void delete(long j);

    private static native boolean getCut_0(long j);

    private static native int getExcludeRange_0(long j);

    private static native int getMaxBits_0(long j);

    private static native void process_0(long j, long j2, long j3, long j4, long j5);

    private static native void process_1(long j, long j2, long j3);

    private static native void setCut_0(long j, boolean z);

    private static native void setExcludeRange_0(long j, int i);

    private static native void setMaxBits_0(long j, int i);

    private static native void shiftMat_0(long j, long j2, long j3, double d, double d2);

    @Override // org.opencv.photo.AlignExposures, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
