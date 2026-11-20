.class public Lorg/opencv/features2d/AffineFeature;
.super Lorg/opencv/features2d/Feature2D;
.source "AffineFeature.java"


# direct methods
.method private static native create_0(JIIFF)J
.end method

.method private static native create_1(JIIF)J
.end method

.method private static native create_2(JII)J
.end method

.method private static native create_3(JI)J
.end method

.method private static native create_4(J)J
.end method

.method private static native delete(J)V
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getViewParams_0(JJJ)V
.end method

.method private static native setViewParams_0(JJJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 114
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/AffineFeature;->delete(J)V

    return-void
.end method
