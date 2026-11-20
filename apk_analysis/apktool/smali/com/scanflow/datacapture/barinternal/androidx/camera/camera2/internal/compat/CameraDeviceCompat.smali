.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat;
.super Ljava/lang/Object;
.source "CameraDeviceCompat.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$CameraDeviceCompatImpl;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$StateCallbackExecutorWrapper;
    }
.end annotation


# instance fields
.field private final mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$CameraDeviceCompatImpl;


# direct methods
.method private constructor <init>(Landroid/hardware/camera2/CameraDevice;Landroid/os/Handler;)V
    .locals 2

    .line 54
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 55
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x1c

    if-lt v0, v1, :cond_0

    .line 56
    new-instance p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatApi28Impl;

    invoke-direct {p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatApi28Impl;-><init>(Landroid/hardware/camera2/CameraDevice;)V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$CameraDeviceCompatImpl;

    return-void

    .line 58
    :cond_0
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatApi24Impl;->create(Landroid/hardware/camera2/CameraDevice;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompatApi24Impl;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$CameraDeviceCompatImpl;

    return-void
.end method

.method public static toCameraDeviceCompat(Landroid/hardware/camera2/CameraDevice;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat;
    .locals 1

    .line 97
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat;-><init>(Landroid/hardware/camera2/CameraDevice;Landroid/os/Handler;)V

    return-object v0
.end method


# virtual methods
.method public createCaptureSession(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;)V
    .locals 1

    .line 125
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$CameraDeviceCompatImpl;

    invoke-interface {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraDeviceCompat$CameraDeviceCompatImpl;->createCaptureSession(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/params/SessionConfigurationCompat;)V

    return-void
.end method
