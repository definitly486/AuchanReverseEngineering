.class public Lorg/opencv/video/FarnebackOpticalFlow;
.super Lorg/opencv/video/DenseOpticalFlow;
.source "FarnebackOpticalFlow.java"


# direct methods
.method private static native create_0(IDZIIIDI)J
.end method

.method private static native create_1(IDZIIID)J
.end method

.method private static native create_2(IDZIII)J
.end method

.method private static native create_3(IDZII)J
.end method

.method private static native create_4(IDZI)J
.end method

.method private static native create_5(IDZ)J
.end method

.method private static native create_6(ID)J
.end method

.method private static native create_7(I)J
.end method

.method private static native create_8()J
.end method

.method private static native delete(J)V
.end method

.method private static native getFastPyramids_0(J)Z
.end method

.method private static native getFlags_0(J)I
.end method

.method private static native getNumIters_0(J)I
.end method

.method private static native getNumLevels_0(J)I
.end method

.method private static native getPolyN_0(J)I
.end method

.method private static native getPolySigma_0(J)D
.end method

.method private static native getPyrScale_0(J)D
.end method

.method private static native getWinSize_0(J)I
.end method

.method private static native setFastPyramids_0(JZ)V
.end method

.method private static native setFlags_0(JI)V
.end method

.method private static native setNumIters_0(JI)V
.end method

.method private static native setNumLevels_0(JI)V
.end method

.method private static native setPolyN_0(JI)V
.end method

.method private static native setPolySigma_0(JD)V
.end method

.method private static native setPyrScale_0(JD)V
.end method

.method private static native setWinSize_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 207
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/FarnebackOpticalFlow;->delete(J)V

    return-void
.end method
