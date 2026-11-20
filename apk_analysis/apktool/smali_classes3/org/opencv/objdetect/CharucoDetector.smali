.class public Lorg/opencv/objdetect/CharucoDetector;
.super Lorg/opencv/core/Algorithm;
.source "CharucoDetector.java"


# direct methods
.method private static native CharucoDetector_0(JJJJ)J
.end method

.method private static native CharucoDetector_1(JJJ)J
.end method

.method private static native CharucoDetector_2(JJ)J
.end method

.method private static native CharucoDetector_3(J)J
.end method

.method private static native delete(J)V
.end method

.method private static native detectBoard_0(JJJJJJ)V
.end method

.method private static native detectBoard_1(JJJJJ)V
.end method

.method private static native detectBoard_2(JJJJ)V
.end method

.method private static native detectDiamonds_0(JJJJJJ)V
.end method

.method private static native detectDiamonds_1(JJJJJ)V
.end method

.method private static native detectDiamonds_2(JJJJ)V
.end method

.method private static native getBoard_0(J)J
.end method

.method private static native getCharucoParameters_0(J)J
.end method

.method private static native getDetectorParameters_0(J)J
.end method

.method private static native getRefineParameters_0(J)J
.end method

.method private static native setBoard_0(JJ)V
.end method

.method private static native setCharucoParameters_0(JJ)V
.end method

.method private static native setDetectorParameters_0(JJ)V
.end method

.method private static native setRefineParameters_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 330
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/CharucoDetector;->delete(J)V

    return-void
.end method
