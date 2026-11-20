.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/compat/Api24Impl;
.super Ljava/lang/Object;
.source "Api24Impl.java"


# direct methods
.method public static getClientAudioSessionId(Landroid/media/AudioRecordingConfiguration;)I
    .locals 0

    .line 48
    invoke-virtual {p0}, Landroid/media/AudioRecordingConfiguration;->getClientAudioSessionId()I

    move-result p0

    return p0
.end method

.method public static getTimestamp(Landroid/media/AudioRecord;Landroid/media/AudioTimestamp;I)I
    .locals 0

    .line 40
    invoke-virtual {p0, p1, p2}, Landroid/media/AudioRecord;->getTimestamp(Landroid/media/AudioTimestamp;I)I

    move-result p0

    return p0
.end method
