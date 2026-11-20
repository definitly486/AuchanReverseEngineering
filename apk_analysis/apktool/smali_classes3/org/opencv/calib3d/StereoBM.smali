.class public Lorg/opencv/calib3d/StereoBM;
.super Lorg/opencv/calib3d/StereoMatcher;
.source "StereoBM.java"


# direct methods
.method private static native create_0(II)J
.end method

.method private static native create_1(I)J
.end method

.method private static native create_2()J
.end method

.method private static native delete(J)V
.end method

.method private static native getPreFilterCap_0(J)I
.end method

.method private static native getPreFilterSize_0(J)I
.end method

.method private static native getPreFilterType_0(J)I
.end method

.method private static native getROI1_0(J)[D
.end method

.method private static native getROI2_0(J)[D
.end method

.method private static native getSmallerBlockSize_0(J)I
.end method

.method private static native getTextureThreshold_0(J)I
.end method

.method private static native getUniquenessRatio_0(J)I
.end method

.method private static native setPreFilterCap_0(JI)V
.end method

.method private static native setPreFilterSize_0(JI)V
.end method

.method private static native setPreFilterType_0(JI)V
.end method

.method private static native setROI1_0(JIIII)V
.end method

.method private static native setROI2_0(JIIII)V
.end method

.method private static native setSmallerBlockSize_0(JI)V
.end method

.method private static native setTextureThreshold_0(JI)V
.end method

.method private static native setUniquenessRatio_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 283
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/calib3d/StereoBM;->delete(J)V

    return-void
.end method
