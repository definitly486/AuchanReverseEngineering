.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;
.super Ljava/lang/Object;
.source "AudioSettings.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;
    }
.end annotation


# static fields
.field public static final COMMON_SAMPLE_RATES:Ljava/util/List;


# direct methods
.method static constructor <clinit>()V
    .locals 7

    const v0, 0xbb80

    .line 40
    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v1

    const v0, 0xac44

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    const/16 v0, 0x5622

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v3

    const/16 v0, 0x2b11

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v4

    const/16 v0, 0x1f40

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v5

    const/16 v0, 0x12c0

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v6

    filled-new-array/range {v1 .. v6}, [Ljava/lang/Integer;

    move-result-object v0

    invoke-static {v0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object v0

    .line 39
    invoke-static {v0}, Ljava/util/Collections;->unmodifiableList(Ljava/util/List;)Ljava/util/List;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->COMMON_SAMPLE_RATES:Ljava/util/List;

    return-void
.end method

.method constructor <init>()V
    .locals 0

    .line 85
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static builder()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;
    .locals 2

    .line 46
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AutoValue_AudioSettings$Builder;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AutoValue_AudioSettings$Builder;-><init>()V

    const/4 v1, -0x1

    .line 47
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AutoValue_AudioSettings$Builder;->setAudioSource(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;

    move-result-object v0

    .line 48
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;->setSampleRate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;

    move-result-object v0

    .line 49
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;->setChannelCount(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;

    move-result-object v0

    .line 50
    invoke-virtual {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;->setAudioFormat(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;

    move-result-object v0

    return-object v0
.end method


# virtual methods
.method public abstract getAudioFormat()I
.end method

.method public abstract getAudioSource()I
.end method

.method public getBytesPerFrame()I
    .locals 2

    .line 90
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getAudioFormat()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getChannelCount()I

    move-result v1

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioUtils;->getBytesPerFrame(II)I

    move-result v0

    return v0
.end method

.method public abstract getChannelCount()I
.end method

.method public abstract getSampleRate()I
.end method
