.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks;
.super Ljava/lang/Object;
.source "Camera2CaptureCallbacks.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks$NoOpSessionCaptureCallback;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks$ComboSessionCaptureCallback;
    }
.end annotation


# direct methods
.method static createComboCallback(Ljava/util/List;)Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;
    .locals 1

    .line 51
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks$ComboSessionCaptureCallback;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks$ComboSessionCaptureCallback;-><init>(Ljava/util/List;)V

    return-object v0
.end method

.method public static varargs createComboCallback([Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;
    .locals 0

    .line 58
    invoke-static {p0}, Ljava/util/Arrays;->asList([Ljava/lang/Object;)Ljava/util/List;

    move-result-object p0

    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks;->createComboCallback(Ljava/util/List;)Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;

    move-result-object p0

    return-object p0
.end method

.method public static createNoOpCallback()Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;
    .locals 1

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks$NoOpSessionCaptureCallback;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CaptureCallbacks$NoOpSessionCaptureCallback;-><init>()V

    return-object v0
.end method
