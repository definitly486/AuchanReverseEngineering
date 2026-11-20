.class interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CaptureSessionInterface;
.super Ljava/lang/Object;
.source "CaptureSessionInterface.java"


# virtual methods
.method public abstract cancelIssuedCaptureRequests()V
.end method

.method public abstract close()V
.end method

.method public abstract getCaptureConfigs()Ljava/util/List;
.end method

.method public abstract getSessionConfig()Landroidx/camera/core/impl/SessionConfig;
.end method

.method public abstract isInOpenState()Z
.end method

.method public abstract issueCaptureRequests(Ljava/util/List;)V
.end method

.method public abstract open(Landroidx/camera/core/impl/SessionConfig;Landroid/hardware/camera2/CameraDevice;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;)Lcom/google/common/util/concurrent/ListenableFuture;
.end method

.method public abstract release(Z)Lcom/google/common/util/concurrent/ListenableFuture;
.end method

.method public abstract setSessionConfig(Landroidx/camera/core/impl/SessionConfig;)V
.end method

.method public abstract setStreamUseCaseMap(Ljava/util/Map;)V
.end method
