.class public Lorg/opencv/objdetect/DetectorParameters;
.super Ljava/lang/Object;
.source "DetectorParameters.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native DetectorParameters_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_adaptiveThreshConstant_0(J)D
.end method

.method private static native get_adaptiveThreshWinSizeMax_0(J)I
.end method

.method private static native get_adaptiveThreshWinSizeMin_0(J)I
.end method

.method private static native get_adaptiveThreshWinSizeStep_0(J)I
.end method

.method private static native get_aprilTagCriticalRad_0(J)F
.end method

.method private static native get_aprilTagDeglitch_0(J)I
.end method

.method private static native get_aprilTagMaxLineFitMse_0(J)F
.end method

.method private static native get_aprilTagMaxNmaxima_0(J)I
.end method

.method private static native get_aprilTagMinClusterPixels_0(J)I
.end method

.method private static native get_aprilTagMinWhiteBlackDiff_0(J)I
.end method

.method private static native get_aprilTagQuadDecimate_0(J)F
.end method

.method private static native get_aprilTagQuadSigma_0(J)F
.end method

.method private static native get_cornerRefinementMaxIterations_0(J)I
.end method

.method private static native get_cornerRefinementMethod_0(J)I
.end method

.method private static native get_cornerRefinementMinAccuracy_0(J)D
.end method

.method private static native get_cornerRefinementWinSize_0(J)I
.end method

.method private static native get_detectInvertedMarker_0(J)Z
.end method

.method private static native get_errorCorrectionRate_0(J)D
.end method

.method private static native get_markerBorderBits_0(J)I
.end method

.method private static native get_maxErroneousBitsInBorderRate_0(J)D
.end method

.method private static native get_maxMarkerPerimeterRate_0(J)D
.end method

.method private static native get_minCornerDistanceRate_0(J)D
.end method

.method private static native get_minDistanceToBorder_0(J)I
.end method

.method private static native get_minGroupDistance_0(J)F
.end method

.method private static native get_minMarkerDistanceRate_0(J)D
.end method

.method private static native get_minMarkerLengthRatioOriginalImg_0(J)F
.end method

.method private static native get_minMarkerPerimeterRate_0(J)D
.end method

.method private static native get_minOtsuStdDev_0(J)D
.end method

.method private static native get_minSideLengthCanonicalImg_0(J)I
.end method

.method private static native get_perspectiveRemoveIgnoredMarginPerCell_0(J)D
.end method

.method private static native get_perspectiveRemovePixelPerCell_0(J)I
.end method

.method private static native get_polygonalApproxAccuracyRate_0(J)D
.end method

.method private static native get_relativeCornerRefinmentWinSize_0(J)F
.end method

.method private static native get_useAruco3Detection_0(J)Z
.end method

.method private static native set_adaptiveThreshConstant_0(JD)V
.end method

.method private static native set_adaptiveThreshWinSizeMax_0(JI)V
.end method

.method private static native set_adaptiveThreshWinSizeMin_0(JI)V
.end method

.method private static native set_adaptiveThreshWinSizeStep_0(JI)V
.end method

.method private static native set_aprilTagCriticalRad_0(JF)V
.end method

.method private static native set_aprilTagDeglitch_0(JI)V
.end method

.method private static native set_aprilTagMaxLineFitMse_0(JF)V
.end method

.method private static native set_aprilTagMaxNmaxima_0(JI)V
.end method

.method private static native set_aprilTagMinClusterPixels_0(JI)V
.end method

.method private static native set_aprilTagMinWhiteBlackDiff_0(JI)V
.end method

.method private static native set_aprilTagQuadDecimate_0(JF)V
.end method

.method private static native set_aprilTagQuadSigma_0(JF)V
.end method

.method private static native set_cornerRefinementMaxIterations_0(JI)V
.end method

.method private static native set_cornerRefinementMethod_0(JI)V
.end method

.method private static native set_cornerRefinementMinAccuracy_0(JD)V
.end method

.method private static native set_cornerRefinementWinSize_0(JI)V
.end method

.method private static native set_detectInvertedMarker_0(JZ)V
.end method

.method private static native set_errorCorrectionRate_0(JD)V
.end method

.method private static native set_markerBorderBits_0(JI)V
.end method

.method private static native set_maxErroneousBitsInBorderRate_0(JD)V
.end method

.method private static native set_maxMarkerPerimeterRate_0(JD)V
.end method

.method private static native set_minCornerDistanceRate_0(JD)V
.end method

.method private static native set_minDistanceToBorder_0(JI)V
.end method

.method private static native set_minGroupDistance_0(JF)V
.end method

.method private static native set_minMarkerDistanceRate_0(JD)V
.end method

.method private static native set_minMarkerLengthRatioOriginalImg_0(JF)V
.end method

.method private static native set_minMarkerPerimeterRate_0(JD)V
.end method

.method private static native set_minOtsuStdDev_0(JD)V
.end method

.method private static native set_minSideLengthCanonicalImg_0(JI)V
.end method

.method private static native set_perspectiveRemoveIgnoredMarginPerCell_0(JD)V
.end method

.method private static native set_perspectiveRemovePixelPerCell_0(JI)V
.end method

.method private static native set_polygonalApproxAccuracyRate_0(JD)V
.end method

.method private static native set_relativeCornerRefinmentWinSize_0(JF)V
.end method

.method private static native set_useAruco3Detection_0(JZ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 659
    iget-wide v0, p0, Lorg/opencv/objdetect/DetectorParameters;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/DetectorParameters;->delete(J)V

    return-void
.end method
