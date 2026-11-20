.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;
.super Ljava/lang/Object;
.source "AudioEncoderConfigDefaultResolver.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/core/util/Supplier;


# instance fields
.field private final mAudioProfile:I

.field private final mAudioSettings:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;

.field private final mAudioSpec:Landroidx/camera/video/AudioSpec;

.field private final mInputTimeBase:Landroidx/camera/core/impl/Timebase;

.field private final mMimeType:Ljava/lang/String;


# direct methods
.method public constructor <init>(Ljava/lang/String;ILandroidx/camera/core/impl/Timebase;Landroidx/camera/video/AudioSpec;Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;)V
    .locals 0

    .line 61
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 62
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mMimeType:Ljava/lang/String;

    .line 63
    iput p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioProfile:I

    .line 64
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mInputTimeBase:Landroidx/camera/core/impl/Timebase;

    .line 65
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioSpec:Landroidx/camera/video/AudioSpec;

    .line 66
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioSettings:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;

    return-void
.end method


# virtual methods
.method public get()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig;
    .locals 7

    .line 72
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioSpec:Landroidx/camera/video/AudioSpec;

    invoke-virtual {v0}, Landroidx/camera/video/AudioSpec;->getBitrate()Landroid/util/Range;

    move-result-object v6

    .line 73
    const-string v0, "AudioEncCfgDefaultRslvr"

    const-string v1, "Using fallback AUDIO bitrate"

    invoke-static {v0, v1}, Landroidx/camera/core/Logger;->d(Ljava/lang/String;Ljava/lang/String;)V

    .line 75
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioSettings:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;

    .line 77
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getChannelCount()I

    move-result v2

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioSettings:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;

    .line 78
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getSampleRate()I

    move-result v4

    const v5, 0xbb80

    const v1, 0x26160

    const/4 v3, 0x2

    .line 75
    invoke-static/range {v1 .. v6}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioConfigUtil;->scaleAndClampBitrate(IIIIILandroid/util/Range;)I

    move-result v0

    .line 81
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig;->builder()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mMimeType:Ljava/lang/String;

    .line 82
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;->setMimeType(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;

    move-result-object v1

    iget v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioProfile:I

    .line 83
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;->setProfile(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mInputTimeBase:Landroidx/camera/core/impl/Timebase;

    .line 84
    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;->setInputTimebase(Landroidx/camera/core/impl/Timebase;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioSettings:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;

    .line 85
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getChannelCount()I

    move-result v2

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;->setChannelCount(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;

    move-result-object v1

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->mAudioSettings:Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;

    .line 86
    invoke-virtual {v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getSampleRate()I

    move-result v2

    invoke-virtual {v1, v2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;->setSampleRate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;

    move-result-object v1

    .line 87
    invoke-virtual {v1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;->setBitrate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;

    move-result-object v0

    .line 88
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig$Builder;->build()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig;

    move-result-object v0

    return-object v0
.end method

.method public bridge synthetic get()Ljava/lang/Object;
    .locals 1

    .line 33
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/config/AudioEncoderConfigDefaultResolver;->get()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/AudioEncoderConfig;

    move-result-object v0

    return-object v0
.end method
