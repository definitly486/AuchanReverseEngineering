.class public Lorg/opencv/objdetect/QRCodeDetectorAruco_Params;
.super Ljava/lang/Object;
.source "QRCodeDetectorAruco_Params.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native QRCodeDetectorAruco_Params_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native get_maxColorsMismatch_0(J)F
.end method

.method private static native get_maxModuleSizeMismatch_0(J)F
.end method

.method private static native get_maxPenalties_0(J)F
.end method

.method private static native get_maxRotation_0(J)F
.end method

.method private static native get_maxTimingPatternMismatch_0(J)F
.end method

.method private static native get_minModuleSizeInPyramid_0(J)F
.end method

.method private static native get_scaleTimingPatternScore_0(J)F
.end method

.method private static native set_maxColorsMismatch_0(JF)V
.end method

.method private static native set_maxModuleSizeMismatch_0(JF)V
.end method

.method private static native set_maxPenalties_0(JF)V
.end method

.method private static native set_maxRotation_0(JF)V
.end method

.method private static native set_maxTimingPatternMismatch_0(JF)V
.end method

.method private static native set_minModuleSizeInPyramid_0(JF)V
.end method

.method private static native set_scaleTimingPatternScore_0(JF)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 157
    iget-wide v0, p0, Lorg/opencv/objdetect/QRCodeDetectorAruco_Params;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/QRCodeDetectorAruco_Params;->delete(J)V

    return-void
.end method
