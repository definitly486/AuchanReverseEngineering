.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/compat/Api26Impl;
.super Ljava/lang/Object;
.source "Api26Impl.java"


# direct methods
.method public static createMediaMuxer(Ljava/io/FileDescriptor;I)Landroid/media/MediaMuxer;
    .locals 1

    .line 42
    new-instance v0, Landroid/media/MediaMuxer;

    invoke-direct {v0, p0, p1}, Landroid/media/MediaMuxer;-><init>(Ljava/io/FileDescriptor;I)V

    return-object v0
.end method
