.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks;
.super Ljava/lang/Object;
.source "CameraCaptureSessionStateCallbacks.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks$NoOpSessionStateCallback;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks$ComboSessionStateCallback;
    }
.end annotation


# direct methods
.method public static createComboCallback(Ljava/util/List;)Landroid/hardware/camera2/CameraCaptureSession$StateCallback;
    .locals 2

    .line 52
    invoke-interface {p0}, Ljava/util/List;->isEmpty()Z

    move-result v0

    if-eqz v0, :cond_0

    .line 53
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks;->createNoOpCallback()Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    move-result-object p0

    return-object p0

    .line 54
    :cond_0
    invoke-interface {p0}, Ljava/util/List;->size()I

    move-result v0

    const/4 v1, 0x1

    if-ne v0, v1, :cond_1

    const/4 v0, 0x0

    .line 55
    invoke-interface {p0, v0}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object p0

    check-cast p0, Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    return-object p0

    .line 57
    :cond_1
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks$ComboSessionStateCallback;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks$ComboSessionStateCallback;-><init>(Ljava/util/List;)V

    return-object v0
.end method

.method public static createNoOpCallback()Landroid/hardware/camera2/CameraCaptureSession$StateCallback;
    .locals 1

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks$NoOpSessionStateCallback;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks$NoOpSessionStateCallback;-><init>()V

    return-object v0
.end method
