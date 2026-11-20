.class public Lorg/opencv/features2d/SimpleBlobDetector;
.super Lorg/opencv/features2d/Feature2D;
.source "SimpleBlobDetector.java"


# direct methods
.method private static native create_0(J)J
.end method

.method private static native create_1()J
.end method

.method private static native delete(J)V
.end method

.method private static native getBlobContours_0(J)J
.end method

.method private static native getDefaultName_0(J)Ljava/lang/String;
.end method

.method private static native getParams_0(J)J
.end method

.method private static native setParams_0(JJ)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 121
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/SimpleBlobDetector;->delete(J)V

    return-void
.end method
