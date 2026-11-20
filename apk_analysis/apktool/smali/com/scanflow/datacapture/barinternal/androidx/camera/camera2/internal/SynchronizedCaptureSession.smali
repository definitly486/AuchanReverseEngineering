.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;
.super Ljava/lang/Object;
.source "SynchronizedCaptureSession.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$OpenerBuilder;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;
    }
.end annotation


# virtual methods
.method public abstract abortCaptures()V
.end method

.method public abstract captureBurstRequests(Ljava/util/List;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I
.end method

.method public abstract close()V
.end method

.method public abstract finishClose()V
.end method

.method public abstract getDevice()Landroid/hardware/camera2/CameraDevice;
.end method

.method public abstract getOpeningBlocker()Lcom/google/common/util/concurrent/ListenableFuture;
.end method

.method public abstract getStateCallback()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;
.end method

.method public abstract onCameraDeviceError(I)V
.end method

.method public abstract setSingleRepeatingRequest(Landroid/hardware/camera2/CaptureRequest;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I
.end method

.method public abstract stopRepeating()V
.end method

.method public abstract toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;
.end method
