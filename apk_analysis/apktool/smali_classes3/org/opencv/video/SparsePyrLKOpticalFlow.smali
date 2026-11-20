.class public Lorg/opencv/video/SparsePyrLKOpticalFlow;
.super Lorg/opencv/video/SparseOpticalFlow;
.source "SparsePyrLKOpticalFlow.java"


# direct methods
.method private static native create_0(DDIIIDID)J
.end method

.method private static native create_1(DDIIIDI)J
.end method

.method private static native create_2(DDIIID)J
.end method

.method private static native create_3(DDI)J
.end method

.method private static native create_4(DD)J
.end method

.method private static native create_5()J
.end method

.method private static native delete(J)V
.end method

.method private static native getFlags_0(J)I
.end method

.method private static native getMaxLevel_0(J)I
.end method

.method private static native getMinEigThreshold_0(J)D
.end method

.method private static native getTermCriteria_0(J)[D
.end method

.method private static native getWinSize_0(J)[D
.end method

.method private static native setFlags_0(JI)V
.end method

.method private static native setMaxLevel_0(JI)V
.end method

.method private static native setMinEigThreshold_0(JD)V
.end method

.method private static native setTermCriteria_0(JIID)V
.end method

.method private static native setWinSize_0(JDD)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 148
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/SparsePyrLKOpticalFlow;->delete(J)V

    return-void
.end method
