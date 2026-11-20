.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;
.super Ljava/lang/Object;
.source "AudioSettings.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "Builder"
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .line 160
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method abstract autoBuild()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;
.end method

.method public final build()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;
    .locals 4

    .line 136
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;->autoBuild()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;

    move-result-object v0

    .line 138
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getAudioSource()I

    move-result v1

    const-string v2, ""

    const/4 v3, -0x1

    if-ne v1, v3, :cond_0

    .line 139
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " audioSource"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 141
    :cond_0
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getSampleRate()I

    move-result v1

    if-gtz v1, :cond_1

    .line 142
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " sampleRate"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 144
    :cond_1
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getChannelCount()I

    move-result v1

    if-gtz v1, :cond_2

    .line 145
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " channelCount"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 147
    :cond_2
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings;->getAudioFormat()I

    move-result v1

    if-ne v1, v3, :cond_3

    .line 148
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " audioFormat"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v2

    .line 151
    :cond_3
    invoke-virtual {v2}, Ljava/lang/String;->isEmpty()Z

    move-result v1

    if-eqz v1, :cond_4

    return-object v0

    .line 152
    :cond_4
    new-instance v0, Ljava/lang/IllegalArgumentException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v3, "Required settings missing or non-positive:"

    invoke-virtual {v1, v3}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public abstract setAudioFormat(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;
.end method

.method public abstract setAudioSource(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;
.end method

.method public abstract setChannelCount(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;
.end method

.method public abstract setSampleRate(I)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioSettings$Builder;
.end method
