.class public Lorg/opencv/video/TrackerGOTURN;
.super Lorg/opencv/video/Tracker;
.source "TrackerGOTURN.java"


# direct methods
.method private static native create_0(J)J
.end method

.method private static native create_1()J
.end method

.method private static native create_2(J)J
.end method

.method private static native delete(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 73
    iget-wide v0, p0, Lorg/opencv/video/Tracker;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/TrackerGOTURN;->delete(J)V

    return-void
.end method
