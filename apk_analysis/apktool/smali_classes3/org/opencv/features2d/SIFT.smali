.class public Lorg/opencv/features2d/SIFT;
.super Lorg/opencv/features2d/Feature2D;
.source "SIFT.java"


# direct methods
.method private static native create_0(IIDDDZ)J
.end method

.method private static native create_1(IIDDD)J
.end method

.method private static native create_2(IIDD)J
.end method

.method private static native create_3(IID)J
.end method

.method private static native create_4(II)J
.end method

.method private static native create_5(I)J
.end method

.method private static native create_6()J
.end method

.method private static native create_7(IIDDDIZ)J
.end method

.method private static native create_8(IIDDDI)J
.end method

.method private static native delete(J)V
.end method

.method private static native getContrastThreshold_0(J)D
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getEdgeThreshold_0(J)D
.end method

.method private static native getNFeatures_0(J)I
.end method

.method private static native getNOctaveLayers_0(J)I
.end method

.method private static native getSigma_0(J)D
.end method

.method private static native setContrastThreshold_0(JD)V
.end method

.method private static native setEdgeThreshold_0(JD)V
.end method

.method private static native setNFeatures_0(JI)V
.end method

.method private static native setNOctaveLayers_0(JI)V
.end method

.method private static native setSigma_0(JD)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 386
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/SIFT;->delete(J)V

    return-void
.end method
