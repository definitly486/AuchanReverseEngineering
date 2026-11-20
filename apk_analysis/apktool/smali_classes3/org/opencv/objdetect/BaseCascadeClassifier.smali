.class public Lorg/opencv/objdetect/BaseCascadeClassifier;
.super Lorg/opencv/core/Algorithm;
.source "BaseCascadeClassifier.java"


# direct methods
.method private static native delete(J)V
.end method


# virtual methods
.method protected finalize()V
    .locals 2

    .line 19
    iget-wide v0, p0, Lorg/opencv/core/Algorithm;->nativeObj:J

    invoke-static {v0, v1}, Lorg/opencv/objdetect/BaseCascadeClassifier;->delete(J)V

    return-void
.end method
