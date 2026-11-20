.class public Lorg/opencv/video/VariationalRefinement;
.super Lorg/opencv/video/DenseOpticalFlow;
.source "VariationalRefinement.java"


# direct methods
.method private static native calcUV_0(JJJJJ)V
.end method

.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method

.method private static native getAlpha_0(J)F
.end method

.method private static native getDelta_0(J)F
.end method

.method private static native getEpsilon_0(J)F
.end method

.method private static native getFixedPointIterations_0(J)I
.end method

.method private static native getGamma_0(J)F
.end method

.method private static native getOmega_0(J)F
.end method

.method private static native getSorIterations_0(J)I
.end method

.method private static native setAlpha_0(JF)V
.end method

.method private static native setDelta_0(JF)V
.end method

.method private static native setEpsilon_0(JF)V
.end method

.method private static native setFixedPointIterations_0(JI)V
.end method

.method private static native setGamma_0(JF)V
.end method

.method private static native setOmega_0(JF)V
.end method

.method private static native setSorIterations_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 251
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/VariationalRefinement;->delete(J)V

    return-void
.end method
