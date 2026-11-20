.class public Lorg/opencv/photo/CalibrateCRF;
.super Lorg/opencv/core/Algorithm;
.source "CalibrateCRF.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native process_0(JJJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 42
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/photo/CalibrateCRF;->delete(J)V

    return-void
.end method
