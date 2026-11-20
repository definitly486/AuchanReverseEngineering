.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat$CameraManagerCompatImpl;
.super Ljava/lang/Object;
.source "CameraManagerCompat.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "CameraManagerCompatImpl"
.end annotation


# direct methods
.method public static from(Landroid/content/Context;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompat$CameraManagerCompatImpl;
    .locals 2

    .line 292
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x1e

    if-lt v0, v1, :cond_0

    .line 293
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatApi30Impl;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatApi30Impl;-><init>(Landroid/content/Context;)V

    return-object p1

    :cond_0
    const/16 v1, 0x1d

    if-lt v0, v1, :cond_1

    .line 295
    new-instance p1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatApi29Impl;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatApi29Impl;-><init>(Landroid/content/Context;)V

    return-object p1

    :cond_1
    const/16 v1, 0x1c

    if-lt v0, v1, :cond_2

    .line 298
    invoke-static {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatApi28Impl;->create(Landroid/content/Context;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatApi28Impl;

    move-result-object p0

    return-object p0

    .line 301
    :cond_2
    invoke-static {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatBaseImpl;->create(Landroid/content/Context;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraManagerCompatBaseImpl;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public abstract getCameraCharacteristics(Ljava/lang/String;)Landroid/hardware/camera2/CameraCharacteristics;
.end method

.method public abstract getCameraIdList()[Ljava/lang/String;
.end method

.method public abstract getConcurrentCameraIds()Ljava/util/Set;
.end method

.method public abstract openCamera(Ljava/lang/String;Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraDevice$StateCallback;)V
.end method

.method public abstract registerAvailabilityCallback(Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraManager$AvailabilityCallback;)V
.end method

.method public abstract unregisterAvailabilityCallback(Landroid/hardware/camera2/CameraManager$AvailabilityCallback;)V
.end method
