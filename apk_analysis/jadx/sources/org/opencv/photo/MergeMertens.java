package org.opencv.photo;

/* JADX INFO: loaded from: classes3.dex */
public class MergeMertens extends MergeExposures {
    private static native void delete(long j);

    private static native float getContrastWeight_0(long j);

    private static native float getExposureWeight_0(long j);

    private static native float getSaturationWeight_0(long j);

    private static native void process_0(long j, long j2, long j3, long j4, long j5);

    private static native void process_1(long j, long j2, long j3);

    private static native void setContrastWeight_0(long j, float f);

    private static native void setExposureWeight_0(long j, float f);

    private static native void setSaturationWeight_0(long j, float f);

    @Override // org.opencv.photo.MergeExposures, org.opencv.core.Algorithm
    protected void finalize() {
        delete(this.nativeObj);
    }
}
