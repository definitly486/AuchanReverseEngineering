.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream;
.super Ljava/lang/Object;
.source "AudioStream.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$AudioStreamException;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$AudioStreamCallback;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$PacketInfo;
    }
.end annotation


# virtual methods
.method public abstract read(Ljava/nio/ByteBuffer;)Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$PacketInfo;
.end method

.method public abstract release()V
.end method

.method public abstract setCallback(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/audio/AudioStream$AudioStreamCallback;Ljava/util/concurrent/Executor;)V
.end method

.method public abstract start()V
.end method

.method public abstract stop()V
.end method
