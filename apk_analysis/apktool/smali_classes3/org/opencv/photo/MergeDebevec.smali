.class public Lorg/opencv/photo/MergeDebevec;
.super Lorg/opencv/photo/MergeExposures;
.source "MergeDebevec.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native process_0(JJJJJ)V
.end method

.method private static native process_1(JJJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 48
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/photo/MergeDebevec;->delete(J)V

    return-void
.end method
