package org.opencv.video;

/* JADX INFO: loaded from: classes3.dex */
public class TrackerMIL_Params {
    protected final long nativeObj;

    private static native long TrackerMIL_Params_0();

    private static native void delete(long j);

    private static native int get_featureSetNumFeatures_0(long j);

    private static native float get_samplerInitInRadius_0(long j);

    private static native int get_samplerInitMaxNegNum_0(long j);

    private static native float get_samplerSearchWinSize_0(long j);

    private static native float get_samplerTrackInRadius_0(long j);

    private static native int get_samplerTrackMaxNegNum_0(long j);

    private static native int get_samplerTrackMaxPosNum_0(long j);

    private static native void set_featureSetNumFeatures_0(long j, int i);

    private static native void set_samplerInitInRadius_0(long j, float f);

    private static native void set_samplerInitMaxNegNum_0(long j, int i);

    private static native void set_samplerSearchWinSize_0(long j, float f);

    private static native void set_samplerTrackInRadius_0(long j, float f);

    private static native void set_samplerTrackMaxNegNum_0(long j, int i);

    private static native void set_samplerTrackMaxPosNum_0(long j, int i);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
