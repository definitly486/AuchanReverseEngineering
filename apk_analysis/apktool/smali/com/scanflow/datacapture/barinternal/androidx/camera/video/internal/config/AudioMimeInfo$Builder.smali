.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioMimeInfo$Builder;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/MimeInfo$Builder;
.source "AudioMimeInfo.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioMimeInfo;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "Builder"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 57
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/MimeInfo$Builder;-><init>()V

    return-void
.end method


# virtual methods
.method public abstract build()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioMimeInfo;
.end method

.method public abstract setCompatibleAudioProfile(Landroidx/camera/core/impl/EncoderProfilesProxy$AudioProfileProxy;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioMimeInfo$Builder;
.end method
