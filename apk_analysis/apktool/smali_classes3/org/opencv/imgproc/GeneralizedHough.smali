.class public Lorg/opencv/imgproc/GeneralizedHough;
.super Lorg/opencv/core/Algorithm;
.source "GeneralizedHough.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native detect_0(JJJJ)V
.end method

.method private static native detect_1(JJJ)V
.end method

.method private static native detect_2(JJJJJJ)V
.end method

.method private static native detect_3(JJJJJ)V
.end method

.method private static native getCannyHighThresh_0(J)I
.end method

.method private static native getCannyLowThresh_0(J)I
.end method

.method private static native getDp_0(J)D
.end method

.method private static native getMaxBufferSize_0(J)I
.end method

.method private static native getMinDist_0(J)D
.end method

.method private static native setCannyHighThresh_0(JI)V
.end method

.method private static native setCannyLowThresh_0(JI)V
.end method

.method private static native setDp_0(JD)V
.end method

.method private static native setMaxBufferSize_0(JI)V
.end method

.method private static native setMinDist_0(JD)V
.end method

.method private static native setTemplate_0(JJDD)V
.end method

.method private static native setTemplate_1(JJ)V
.end method

.method private static native setTemplate_2(JJJJDD)V
.end method

.method private static native setTemplate_3(JJJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 165
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/imgproc/GeneralizedHough;->delete(J)V

    return-void
.end method
