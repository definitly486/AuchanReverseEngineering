.class public Lorg/opencv/imgproc/IntelligentScissorsMB;
.super Ljava/lang/Object;
.source "IntelligentScissorsMB.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native IntelligentScissorsMB_0()J
.end method

.method private static native applyImageFeatures_0(JJJJJ)J
.end method

.method private static native applyImageFeatures_1(JJJJ)J
.end method

.method private static native applyImage_0(JJ)J
.end method

.method private static native buildMap_0(JDD)V
.end method

.method private static native delete(J)V
.end method

.method private static native getContour_0(JDDJZ)V
.end method

.method private static native getContour_1(JDDJ)V
.end method

.method private static native setEdgeFeatureCannyParameters_0(JDDIZ)J
.end method

.method private static native setEdgeFeatureCannyParameters_1(JDDI)J
.end method

.method private static native setEdgeFeatureCannyParameters_2(JDD)J
.end method

.method private static native setEdgeFeatureZeroCrossingParameters_0(JF)J
.end method

.method private static native setEdgeFeatureZeroCrossingParameters_1(J)J
.end method

.method private static native setGradientMagnitudeMaxLimit_0(JF)J
.end method

.method private static native setGradientMagnitudeMaxLimit_1(J)J
.end method

.method private static native setWeights_0(JFFF)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 286
    iget-wide v0, p0, Lorg/opencv/imgproc/IntelligentScissorsMB;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/imgproc/IntelligentScissorsMB;->delete(J)V

    return-void
.end method
