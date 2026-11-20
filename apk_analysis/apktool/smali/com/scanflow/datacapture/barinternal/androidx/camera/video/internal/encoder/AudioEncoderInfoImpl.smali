.class public Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderInfoImpl;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderInfoImpl;
.source "AudioEncoderInfoImpl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderInfo;


# instance fields
.field private final mAudioCapabilities:Landroid/media/MediaCodecInfo$AudioCapabilities;


# direct methods
.method constructor <init>(Landroid/media/MediaCodecInfo;Ljava/lang/String;)V
    .locals 0

    .line 55
    invoke-direct {p0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderInfoImpl;-><init>(Landroid/media/MediaCodecInfo;Ljava/lang/String;)V

    .line 56
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderInfoImpl;->mCodecCapabilities:Landroid/media/MediaCodecInfo$CodecCapabilities;

    invoke-virtual {p1}, Landroid/media/MediaCodecInfo$CodecCapabilities;->getAudioCapabilities()Landroid/media/MediaCodecInfo$AudioCapabilities;

    move-result-object p1

    invoke-static {p1}, Ljava/util/Objects;->requireNonNull(Ljava/lang/Object;)Ljava/lang/Object;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderInfoImpl;->mAudioCapabilities:Landroid/media/MediaCodecInfo$AudioCapabilities;

    return-void
.end method
