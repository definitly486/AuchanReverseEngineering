.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;
.super Ljava/lang/Object;
.source "SynchronizedCaptureSession.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "Opener"
.end annotation


# virtual methods
.method public abstract createSessionConfigurationCompat(ILjava/util/List;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;
.end method

.method public abstract getExecutor()Ljava/util/concurrent/Executor;
.end method

.method public abstract openCaptureSession(Landroid/hardware/camera2/CameraDevice;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;Ljava/util/List;)Lcom/google/common/util/concurrent/ListenableFuture;
.end method

.method public abstract startWithDeferrableSurface(Ljava/util/List;J)Lcom/google/common/util/concurrent/ListenableFuture;
.end method

.method public abstract stop()Z
.end method
