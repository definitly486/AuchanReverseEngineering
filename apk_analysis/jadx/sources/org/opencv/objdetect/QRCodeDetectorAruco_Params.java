package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class QRCodeDetectorAruco_Params {
    protected final long nativeObj;

    private static native long QRCodeDetectorAruco_Params_0();

    private static native void delete(long j);

    private static native float get_maxColorsMismatch_0(long j);

    private static native float get_maxModuleSizeMismatch_0(long j);

    private static native float get_maxPenalties_0(long j);

    private static native float get_maxRotation_0(long j);

    private static native float get_maxTimingPatternMismatch_0(long j);

    private static native float get_minModuleSizeInPyramid_0(long j);

    private static native float get_scaleTimingPatternScore_0(long j);

    private static native void set_maxColorsMismatch_0(long j, float f);

    private static native void set_maxModuleSizeMismatch_0(long j, float f);

    private static native void set_maxPenalties_0(long j, float f);

    private static native void set_maxRotation_0(long j, float f);

    private static native void set_maxTimingPatternMismatch_0(long j, float f);

    private static native void set_minModuleSizeInPyramid_0(long j, float f);

    private static native void set_scaleTimingPatternScore_0(long j, float f);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
