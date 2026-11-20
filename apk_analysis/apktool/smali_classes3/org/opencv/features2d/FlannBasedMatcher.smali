.class public Lorg/opencv/features2d/FlannBasedMatcher;
.super Lorg/opencv/features2d/DescriptorMatcher;
.source "FlannBasedMatcher.java"


# direct methods
.method private static native FlannBasedMatcher_0()J
.end method

.method private static native create_0()J
.end method

.method private static native delete(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 45
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/features2d/FlannBasedMatcher;->delete(J)V

    return-void
.end method
