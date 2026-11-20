.class Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;
.super Ljava/lang/Object;
.source "CameraCaptureSessionCompatBaseImpl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl$CameraCaptureSessionCompatParamsApi21;
    }
.end annotation


# instance fields
.field final mCameraCaptureSession:Landroid/hardware/camera2/CameraCaptureSession;

.field final mObject:Ljava/lang/Object;


# direct methods
.method constructor <init>(Landroid/hardware/camera2/CameraCaptureSession;Ljava/lang/Object;)V
    .locals 0

    .line 38
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 39
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/hardware/camera2/CameraCaptureSession;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->mCameraCaptureSession:Landroid/hardware/camera2/CameraCaptureSession;

    .line 40
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->mObject:Ljava/lang/Object;

    return-void
.end method

.method static create(Landroid/hardware/camera2/CameraCaptureSession;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;
    .locals 2

    .line 46
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl$CameraCaptureSessionCompatParamsApi21;

    invoke-direct {v1, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl$CameraCaptureSessionCompatParamsApi21;-><init>(Landroid/os/Handler;)V

    invoke-direct {v0, p0, v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;-><init>(Landroid/hardware/camera2/CameraCaptureSession;Ljava/lang/Object;)V

    return-object v0
.end method


# virtual methods
.method public captureBurstRequests(Ljava/util/List;Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I
    .locals 1

    .line 56
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CaptureCallbackExecutorWrapper;

    invoke-direct {v0, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CaptureCallbackExecutorWrapper;-><init>(Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)V

    .line 59
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->mObject:Ljava/lang/Object;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl$CameraCaptureSessionCompatParamsApi21;

    .line 61
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->mCameraCaptureSession:Landroid/hardware/camera2/CameraCaptureSession;

    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl$CameraCaptureSessionCompatParamsApi21;->mCompatHandler:Landroid/os/Handler;

    invoke-virtual {p3, p1, v0, p2}, Landroid/hardware/camera2/CameraCaptureSession;->captureBurst(Ljava/util/List;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;Landroid/os/Handler;)I

    move-result p1

    return p1
.end method

.method public setSingleRepeatingRequest(Landroid/hardware/camera2/CaptureRequest;Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I
    .locals 1

    .line 94
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CaptureCallbackExecutorWrapper;

    invoke-direct {v0, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CaptureCallbackExecutorWrapper;-><init>(Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)V

    .line 97
    iget-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->mObject:Ljava/lang/Object;

    check-cast p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl$CameraCaptureSessionCompatParamsApi21;

    .line 99
    iget-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->mCameraCaptureSession:Landroid/hardware/camera2/CameraCaptureSession;

    iget-object p2, p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl$CameraCaptureSessionCompatParamsApi21;->mCompatHandler:Landroid/os/Handler;

    invoke-virtual {p3, p1, v0, p2}, Landroid/hardware/camera2/CameraCaptureSession;->setRepeatingRequest(Landroid/hardware/camera2/CaptureRequest;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;Landroid/os/Handler;)I

    move-result p1

    return p1
.end method

.method public unwrap()Landroid/hardware/camera2/CameraCaptureSession;
    .locals 1

    .line 106
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->mCameraCaptureSession:Landroid/hardware/camera2/CameraCaptureSession;

    return-object v0
.end method
