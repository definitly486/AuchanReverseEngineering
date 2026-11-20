.class public Lorg/opencv/video/DISOpticalFlow;
.super Lorg/opencv/video/DenseOpticalFlow;
.source "DISOpticalFlow.java"


# direct methods
.method private static native create_0(I)J
.end method

.method private static native create_1()J
.end method

.method private static native delete(J)V
.end method

.method private static native getFinestScale_0(J)I
.end method

.method private static native getGradientDescentIterations_0(J)I
.end method

.method private static native getPatchSize_0(J)I
.end method

.method private static native getPatchStride_0(J)I
.end method

.method private static native getUseMeanNormalization_0(J)Z
.end method

.method private static native getUseSpatialPropagation_0(J)Z
.end method

.method private static native getVariationalRefinementAlpha_0(J)F
.end method

.method private static native getVariationalRefinementDelta_0(J)F
.end method

.method private static native getVariationalRefinementEpsilon_0(J)F
.end method

.method private static native getVariationalRefinementGamma_0(J)F
.end method

.method private static native getVariationalRefinementIterations_0(J)I
.end method

.method private static native setFinestScale_0(JI)V
.end method

.method private static native setGradientDescentIterations_0(JI)V
.end method

.method private static native setPatchSize_0(JI)V
.end method

.method private static native setPatchStride_0(JI)V
.end method

.method private static native setUseMeanNormalization_0(JZ)V
.end method

.method private static native setUseSpatialPropagation_0(JZ)V
.end method

.method private static native setVariationalRefinementAlpha_0(JF)V
.end method

.method private static native setVariationalRefinementDelta_0(JF)V
.end method

.method private static native setVariationalRefinementEpsilon_0(JF)V
.end method

.method private static native setVariationalRefinementGamma_0(JF)V
.end method

.method private static native setVariationalRefinementIterations_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 372
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/DISOpticalFlow;->delete(J)V

    return-void
.end method
