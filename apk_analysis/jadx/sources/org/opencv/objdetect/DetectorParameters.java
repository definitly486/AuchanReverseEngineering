package org.opencv.objdetect;

/* JADX INFO: loaded from: classes3.dex */
public class DetectorParameters {
    protected final long nativeObj;

    private static native long DetectorParameters_0();

    private static native void delete(long j);

    private static native double get_adaptiveThreshConstant_0(long j);

    private static native int get_adaptiveThreshWinSizeMax_0(long j);

    private static native int get_adaptiveThreshWinSizeMin_0(long j);

    private static native int get_adaptiveThreshWinSizeStep_0(long j);

    private static native float get_aprilTagCriticalRad_0(long j);

    private static native int get_aprilTagDeglitch_0(long j);

    private static native float get_aprilTagMaxLineFitMse_0(long j);

    private static native int get_aprilTagMaxNmaxima_0(long j);

    private static native int get_aprilTagMinClusterPixels_0(long j);

    private static native int get_aprilTagMinWhiteBlackDiff_0(long j);

    private static native float get_aprilTagQuadDecimate_0(long j);

    private static native float get_aprilTagQuadSigma_0(long j);

    private static native int get_cornerRefinementMaxIterations_0(long j);

    private static native int get_cornerRefinementMethod_0(long j);

    private static native double get_cornerRefinementMinAccuracy_0(long j);

    private static native int get_cornerRefinementWinSize_0(long j);

    private static native boolean get_detectInvertedMarker_0(long j);

    private static native double get_errorCorrectionRate_0(long j);

    private static native int get_markerBorderBits_0(long j);

    private static native double get_maxErroneousBitsInBorderRate_0(long j);

    private static native double get_maxMarkerPerimeterRate_0(long j);

    private static native double get_minCornerDistanceRate_0(long j);

    private static native int get_minDistanceToBorder_0(long j);

    private static native float get_minGroupDistance_0(long j);

    private static native double get_minMarkerDistanceRate_0(long j);

    private static native float get_minMarkerLengthRatioOriginalImg_0(long j);

    private static native double get_minMarkerPerimeterRate_0(long j);

    private static native double get_minOtsuStdDev_0(long j);

    private static native int get_minSideLengthCanonicalImg_0(long j);

    private static native double get_perspectiveRemoveIgnoredMarginPerCell_0(long j);

    private static native int get_perspectiveRemovePixelPerCell_0(long j);

    private static native double get_polygonalApproxAccuracyRate_0(long j);

    private static native float get_relativeCornerRefinmentWinSize_0(long j);

    private static native boolean get_useAruco3Detection_0(long j);

    private static native void set_adaptiveThreshConstant_0(long j, double d);

    private static native void set_adaptiveThreshWinSizeMax_0(long j, int i);

    private static native void set_adaptiveThreshWinSizeMin_0(long j, int i);

    private static native void set_adaptiveThreshWinSizeStep_0(long j, int i);

    private static native void set_aprilTagCriticalRad_0(long j, float f);

    private static native void set_aprilTagDeglitch_0(long j, int i);

    private static native void set_aprilTagMaxLineFitMse_0(long j, float f);

    private static native void set_aprilTagMaxNmaxima_0(long j, int i);

    private static native void set_aprilTagMinClusterPixels_0(long j, int i);

    private static native void set_aprilTagMinWhiteBlackDiff_0(long j, int i);

    private static native void set_aprilTagQuadDecimate_0(long j, float f);

    private static native void set_aprilTagQuadSigma_0(long j, float f);

    private static native void set_cornerRefinementMaxIterations_0(long j, int i);

    private static native void set_cornerRefinementMethod_0(long j, int i);

    private static native void set_cornerRefinementMinAccuracy_0(long j, double d);

    private static native void set_cornerRefinementWinSize_0(long j, int i);

    private static native void set_detectInvertedMarker_0(long j, boolean z);

    private static native void set_errorCorrectionRate_0(long j, double d);

    private static native void set_markerBorderBits_0(long j, int i);

    private static native void set_maxErroneousBitsInBorderRate_0(long j, double d);

    private static native void set_maxMarkerPerimeterRate_0(long j, double d);

    private static native void set_minCornerDistanceRate_0(long j, double d);

    private static native void set_minDistanceToBorder_0(long j, int i);

    private static native void set_minGroupDistance_0(long j, float f);

    private static native void set_minMarkerDistanceRate_0(long j, double d);

    private static native void set_minMarkerLengthRatioOriginalImg_0(long j, float f);

    private static native void set_minMarkerPerimeterRate_0(long j, double d);

    private static native void set_minOtsuStdDev_0(long j, double d);

    private static native void set_minSideLengthCanonicalImg_0(long j, int i);

    private static native void set_perspectiveRemoveIgnoredMarginPerCell_0(long j, double d);

    private static native void set_perspectiveRemovePixelPerCell_0(long j, int i);

    private static native void set_polygonalApproxAccuracyRate_0(long j, double d);

    private static native void set_relativeCornerRefinmentWinSize_0(long j, float f);

    private static native void set_useAruco3Detection_0(long j, boolean z);

    protected void finalize() {
        delete(this.nativeObj);
    }
}
