.class public Lorg/opencv/calib3d/StereoSGBM;
.super Lorg/opencv/calib3d/StereoMatcher;
.source "StereoSGBM.java"


# direct methods
.method private static native create_0(IIIIIIIIIII)J
.end method

.method private static native create_1(IIIIIIIIII)J
.end method

.method private static native create_10(I)J
.end method

.method private static native create_11()J
.end method

.method private static native create_2(IIIIIIIII)J
.end method

.method private static native create_3(IIIIIIII)J
.end method

.method private static native create_4(IIIIIII)J
.end method

.method private static native create_5(IIIIII)J
.end method

.method private static native create_6(IIIII)J
.end method

.method private static native create_7(IIII)J
.end method

.method private static native create_8(III)J
.end method

.method private static native create_9(II)J
.end method

.method private static native delete(J)V
.end method

.method private static native getMode_0(J)I
.end method

.method private static native getP1_0(J)I
.end method

.method private static native getP2_0(J)I
.end method

.method private static native getPreFilterCap_0(J)I
.end method

.method private static native getUniquenessRatio_0(J)I
.end method

.method private static native setMode_0(JI)V
.end method

.method private static native setP1_0(JI)V
.end method

.method private static native setP2_0(JI)V
.end method

.method private static native setPreFilterCap_0(JI)V
.end method

.method private static native setUniquenessRatio_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 605
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/calib3d/StereoSGBM;->delete(J)V

    return-void
.end method
