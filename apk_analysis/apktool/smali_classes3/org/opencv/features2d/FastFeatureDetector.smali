.class public Lorg/opencv/features2d/FastFeatureDetector;
.super Lorg/opencv/features2d/Feature2D;
.source "FastFeatureDetector.java"


# direct methods
.method private static native create_0(IZI)J
.end method

.method private static native create_1(IZ)J
.end method

.method private static native create_2(I)J
.end method

.method private static native create_3()J
.end method

.method private static native delete(J)V
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getNonmaxSuppression_0(J)Z
.end method

.method private static native getThreshold_0(J)I
.end method

.method private static native getType_0(J)I
.end method

.method private static native setNonmaxSuppression_0(JZ)V
.end method

.method private static native setThreshold_0(JI)V
.end method

.method private static native setType_0(JI)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 120
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/FastFeatureDetector;->delete(J)V

    return-void
.end method
