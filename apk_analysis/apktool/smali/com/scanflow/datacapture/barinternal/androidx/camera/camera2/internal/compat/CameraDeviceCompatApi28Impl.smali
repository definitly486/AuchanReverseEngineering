.class Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatApi28Impl;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatApi24Impl;
.source "CameraDeviceCompatApi28Impl.java"


# direct methods
.method constructor <init>(Landroid/hardware/camera2/CameraDevice;)V
    .locals 1

    .line 32
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/hardware/camera2/CameraDevice;

    const/4 v0, 0x0

    invoke-direct {p0, p1, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatApi24Impl;-><init>(Landroid/hardware/camera2/CameraDevice;Ljava/lang/Object;)V

    return-void
.end method


# virtual methods
.method public createCaptureSession(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;)V
    .locals 1

    .line 38
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;->unwrap()Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/hardware/camera2/params/SessionConfiguration;

    .line 39
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 42
    :try_start_0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatBaseImpl;->mCameraDevice:Landroid/hardware/camera2/CameraDevice;

    invoke-virtual {v0, p1}, Landroid/hardware/camera2/CameraDevice;->createCaptureSession(Landroid/hardware/camera2/params/SessionConfiguration;)V
    :try_end_0
    .catch Landroid/hardware/camera2/CameraAccessException; {:try_start_0 .. :try_end_0} :catch_0

    return-void

    :catch_0
    move-exception p1

    .line 44
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraAccessExceptionCompat;->toCameraAccessExceptionCompat(Landroid/hardware/camera2/CameraAccessException;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraAccessExceptionCompat;

    move-result-object p1

    throw p1
.end method
