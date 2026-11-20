.class public Lorg/opencv/photo/MergeMertens;
.super Lorg/opencv/photo/MergeExposures;
.source "MergeMertens.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native getContrastWeight_0(J)F
.end method

.method private static native getExposureWeight_0(J)F
.end method

.method private static native getSaturationWeight_0(J)F
.end method

.method private static native process_0(JJJJJ)V
.end method

.method private static native process_1(JJJ)V
.end method

.method private static native setContrastWeight_0(JF)V
.end method

.method private static native setExposureWeight_0(JF)V
.end method

.method private static native setSaturationWeight_0(JF)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 114
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/photo/MergeMertens;->delete(J)V

    return-void
.end method
