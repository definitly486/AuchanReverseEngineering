.class public Lorg/opencv/video/Tracker;
.super Ljava/lang/Object;
.source "Tracker.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native delete(J)V
.end method

.method private static native init_0(JJIIII)V
.end method

.method private static native update_0(JJ[D)Z
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 61
    iget-wide v0, p0, Lorg/opencv/video/Tracker;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/video/Tracker;->delete(J)V

    return-void
.end method
