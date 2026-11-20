.class public Lorg/opencv/videoio/IStreamReader;
.super Ljava/lang/Object;
.source "IStreamReader.java"


# instance fields
.field protected final nativeObj:J


# direct methods
.method private static native delete(J)V
.end method

.method private static native read_0(J[BJ)J
.end method

.method private static native seek_0(JJI)J
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 67
    iget-wide v0, p0, Lorg/opencv/videoio/IStreamReader;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/videoio/IStreamReader;->delete(J)V

    return-void
.end method
