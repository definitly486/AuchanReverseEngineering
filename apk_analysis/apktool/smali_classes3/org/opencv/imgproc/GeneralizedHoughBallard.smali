.class public Lorg/opencv/imgproc/GeneralizedHoughBallard;
.super Lorg/opencv/imgproc/GeneralizedHough;
.source "GeneralizedHoughBallard.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native getLevels_0(J)I
.end method

.method private static native getVotesThreshold_0(J)I
.end method

.method private static native setLevels_0(JI)V
.end method

.method private static native setVotesThreshold_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 59
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/imgproc/GeneralizedHoughBallard;->delete(J)V

    return-void
.end method
