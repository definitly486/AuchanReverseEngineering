.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.super Ljava/lang/Object;
.source "VideoEncoderConfig.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "Builder"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 112
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract build()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig;
.end method

.method public abstract setBitrate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setColorFormat(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setDataSpace(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderDataSpace;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setFrameRate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setIFrameInterval(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setInputTimebase(Landroidx/camera/core/impl/Timebase;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setMimeType(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setProfile(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method

.method public abstract setResolution(Landroid/util/Size;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/VideoEncoderConfig$Builder;
.end method
