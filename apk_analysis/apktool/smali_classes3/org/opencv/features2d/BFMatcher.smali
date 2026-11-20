.class public Lorg/opencv/features2d/BFMatcher;
.super Lorg/opencv/features2d/DescriptorMatcher;
.source "BFMatcher.java"


# direct methods
.method private static native BFMatcher_0(IZ)J
.end method

.method private static native BFMatcher_1(I)J
.end method

.method private static native BFMatcher_2()J
.end method

.method private static native create_0(IZ)J
.end method

.method private static native create_1(I)J
.end method

.method private static native create_2()J
.end method

.method private static native delete(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 117
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/BFMatcher;->delete(J)V

    return-void
.end method
