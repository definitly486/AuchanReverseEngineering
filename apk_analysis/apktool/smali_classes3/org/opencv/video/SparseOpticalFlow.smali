.class public Lorg/opencv/video/SparseOpticalFlow;
.super Lorg/opencv/core/Algorithm;
.source "SparseOpticalFlow.java"


# direct methods
.method private static native calc_0(JJJJJJJ)V
.end method

.method private static native calc_1(JJJJJJ)V
.end method

.method private static native delete(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 56
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/SparseOpticalFlow;->delete(J)V

    return-void
.end method
