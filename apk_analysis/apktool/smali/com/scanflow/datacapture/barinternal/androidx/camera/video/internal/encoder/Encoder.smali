.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder;
.super Ljava/lang/Object;
.source "Encoder.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$ByteBufferInput;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$SurfaceInput;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$EncoderInput;
    }
.end annotation


# virtual methods
.method public abstract getConfiguredBitrate()I
.end method

.method public abstract getEncoderInfo()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderInfo;
.end method

.method public abstract getInput()Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/Encoder$EncoderInput;
.end method

.method public abstract getReleasedFuture()Lcom/google/common/util/concurrent/ListenableFuture;
.end method

.method public abstract pause()V
.end method

.method public abstract release()V
.end method

.method public abstract requestKeyFrame()V
.end method

.method public abstract setEncoderCallback(Lcom/scanflow/datacapture/barinternal/androidx/camera/video/internal/encoder/EncoderCallback;Ljava/util/concurrent/Executor;)V
.end method

.method public abstract start()V
.end method

.method public abstract stop(J)V
.end method
