.class public Lorg/opencv/features2d/MSER;
.super Lorg/opencv/features2d/Feature2D;
.source "MSER.java"


# direct methods
.method private static native create_0(IIIDDIDDI)J
.end method

.method private static native create_1(IIIDDIDD)J
.end method

.method private static native create_2(IIIDDID)J
.end method

.method private static native create_3(IIIDDI)J
.end method

.method private static native create_4(IIIDD)J
.end method

.method private static native create_5(IIID)J
.end method

.method private static native create_6(III)J
.end method

.method private static native create_7(II)J
.end method

.method private static native create_8(I)J
.end method

.method private static native create_9()J
.end method

.method private static native delete(J)V
.end method

.method private static native detectRegions_0(JJJJ)V
.end method

.method private static native getAreaThreshold_0(J)D
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getDelta_0(J)I
.end method

.method private static native getEdgeBlurSize_0(J)I
.end method

.method private static native getMaxArea_0(J)I
.end method

.method private static native getMaxEvolution_0(J)I
.end method

.method private static native getMaxVariation_0(J)D
.end method

.method private static native getMinArea_0(J)I
.end method

.method private static native getMinDiversity_0(J)D
.end method

.method private static native getMinMargin_0(J)D
.end method

.method private static native getPass2Only_0(J)Z
.end method

.method private static native setAreaThreshold_0(JD)V
.end method

.method private static native setDelta_0(JI)V
.end method

.method private static native setEdgeBlurSize_0(JI)V
.end method

.method private static native setMaxArea_0(JI)V
.end method

.method private static native setMaxEvolution_0(JI)V
.end method

.method private static native setMaxVariation_0(JD)V
.end method

.method private static native setMinArea_0(JI)V
.end method

.method private static native setMinDiversity_0(JD)V
.end method

.method private static native setMinMargin_0(JD)V
.end method

.method private static native setPass2Only_0(JZ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 406
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/MSER;->delete(J)V

    return-void
.end method
