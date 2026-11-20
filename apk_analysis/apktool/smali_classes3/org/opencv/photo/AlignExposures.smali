.class public Lorg/opencv/photo/AlignExposures;
.super Lorg/opencv/core/Algorithm;
.source "AlignExposures.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native process_0(JJJJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 45
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/photo/AlignExposures;->delete(J)V

    return-void
.end method
