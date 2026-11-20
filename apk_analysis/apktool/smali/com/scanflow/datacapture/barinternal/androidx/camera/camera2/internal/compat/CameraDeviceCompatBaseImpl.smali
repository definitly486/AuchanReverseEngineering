.class abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatBaseImpl;
.super Ljava/lang/Object;
.source "CameraDeviceCompatBaseImpl.java"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$CameraDeviceCompatImpl;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatBaseImpl$CameraDeviceCompatParamsApi21;
    }
.end annotation


# instance fields
.field final mCameraDevice:Landroid/hardware/camera2/CameraDevice;

.field final mImplParams:Ljava/lang/Object;


# direct methods
.method constructor <init>(Landroid/hardware/camera2/CameraDevice;Ljava/lang/Object;)V
    .locals 0

    .line 41
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 42
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Landroid/hardware/camera2/CameraDevice;

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatBaseImpl;->mCameraDevice:Landroid/hardware/camera2/CameraDevice;

    .line 43
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatBaseImpl;->mImplParams:Ljava/lang/Object;

    return-void
.end method

.method private static checkPhysicalCameraIdValid(Landroid/hardware/camera2/CameraDevice;Ljava/util/List;)V
    .locals 3

    .line 90
    invoke-virtual {p0}, Landroid/hardware/camera2/CameraDevice;->getId()Ljava/lang/String;

    move-result-object p0

    .line 91
    invoke-interface {p1}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p1

    :cond_0
    :goto_0
    invoke-interface {p1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_1

    invoke-interface {p1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;

    .line 92
    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->getPhysicalCameraId()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_0

    .line 93
    invoke-virtual {v0}, Ljava/lang/String;->isEmpty()Z

    move-result v1

    if-nez v1, :cond_0

    .line 94
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Camera "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, ": Camera doesn\'t support physicalCameraId "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v0, ". Ignoring."

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    const-string v1, "CameraDeviceCompat"

    invoke-static {v1, v0}, Landroidx/camera/core/Logger;->w(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    :cond_1
    return-void
.end method

.method static checkPreconditions(Landroid/hardware/camera2/CameraDevice;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;)V
    .locals 1

    .line 62
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 63
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 64
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;->getStateCallback()Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/androidx/core/util/Preconditions;->checkNotNull(Ljava/lang/Object;)Ljava/lang/Object;

    .line 66
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;->getOutputConfigurations()Ljava/util/List;

    move-result-object v0

    if-eqz v0, :cond_1

    .line 70
    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;->getExecutor()Ljava/util/concurrent/Executor;

    move-result-object p1

    if-eqz p1, :cond_0

    .line 74
    invoke-static {p0, v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatBaseImpl;->checkPhysicalCameraIdValid(Landroid/hardware/camera2/CameraDevice;Ljava/util/List;)V

    return-void

    .line 71
    :cond_0
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Invalid executor"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0

    .line 68
    :cond_1
    new-instance p0, Ljava/lang/IllegalArgumentException;

    const-string p1, "Invalid output configurations"

    invoke-direct {p0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw p0
.end method

.method static unpackSurfaces(Ljava/util/List;)Ljava/util/List;
    .locals 2

    .line 53
    new-instance v0, Ljava/util/ArrayList;

    invoke-interface {p0}, Ljava/util/List;->size()I

    move-result v1

    invoke-direct {v0, v1}, Ljava/util/ArrayList;-><init>(I)V

    .line 54
    invoke-interface {p0}, Ljava/util/List;->iterator()Ljava/util/Iterator;

    move-result-object p0

    :goto_0
    invoke-interface {p0}, Ljava/util/Iterator;->hasNext()Z

    move-result v1

    if-eqz v1, :cond_0

    invoke-interface {p0}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;

    .line 55
    invoke-virtual {v1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/OutputConfigurationCompat;->getSurface()Landroid/view/Surface;

    move-result-object v1

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    goto :goto_0

    :cond_0
    return-object v0
.end method
