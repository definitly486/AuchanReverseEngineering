.class public Lorg/opencv/features2d/KAZE;
.super Lorg/opencv/features2d/Feature2D;
.source "KAZE.java"


# direct methods
.method private static native create_0(ZZFIII)J
.end method

.method private static native create_1(ZZFII)J
.end method

.method private static native create_2(ZZFI)J
.end method

.method private static native create_3(ZZF)J
.end method

.method private static native create_4(ZZ)J
.end method

.method private static native create_5(Z)J
.end method

.method private static native create_6()J
.end method

.method private static native delete(J)V
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getDiffusivity_0(J)I
.end method

.method private static native getExtended_0(J)Z
.end method

.method private static native getNOctaveLayers_0(J)I
.end method

.method private static native getNOctaves_0(J)I
.end method

.method private static native getThreshold_0(J)D
.end method

.method private static native getUpright_0(J)Z
.end method

.method private static native setDiffusivity_0(JI)V
.end method

.method private static native setExtended_0(JZ)V
.end method

.method private static native setNOctaveLayers_0(JI)V
.end method

.method private static native setNOctaves_0(JI)V
.end method

.method private static native setThreshold_0(JD)V
.end method

.method private static native setUpright_0(JZ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 247
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/KAZE;->delete(J)V

    return-void
.end method
