.class public Lorg/opencv/photo/TonemapReinhard;
.super Lorg/opencv/photo/Tonemap;
.source "TonemapReinhard.java"


# direct methods
.method private static native delete(J)V
.end method

.method private static native getColorAdaptation_0(J)F
.end method

.method private static native getIntensity_0(J)F
.end method

.method private static native getLightAdaptation_0(J)F
.end method

.method private static native setColorAdaptation_0(JF)V
.end method

.method private static native setIntensity_0(JF)V
.end method

.method private static native setLightAdaptation_0(JF)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 80
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/photo/TonemapReinhard;->delete(J)V

    return-void
.end method
