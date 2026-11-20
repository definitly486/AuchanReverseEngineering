.class public final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;
.super Ljava/lang/Object;
.source "CameraCaptureSessionCompat.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$StateCallbackExecutorWrapper;,
        Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CaptureCallbackExecutorWrapper;
    }
.end annotation


# instance fields
.field private final mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;


# direct methods
.method private constructor <init>(Landroid/hardware/camera2/CameraCaptureSession;Landroid/os/Handler;)V
    .locals 2

    .line 45
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 46
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0x1c

    if-lt v0, v1, :cond_0

    .line 47
    new-instance p2, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatApi28Impl;

    invoke-direct {p2, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatApi28Impl;-><init>(Landroid/hardware/camera2/CameraCaptureSession;)V

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;

    return-void

    .line 49
    :cond_0
    invoke-static {p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompatBaseImpl;->create(Landroid/hardware/camera2/CameraCaptureSession;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;

    move-result-object p1

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;

    return-void
.end method

.method public static toCameraCaptureSessionCompat(Landroid/hardware/camera2/CameraCaptureSession;Landroid/os/Handler;)Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;
    .locals 1

    .line 84
    new-instance v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    invoke-direct {v0, p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;-><init>(Landroid/hardware/camera2/CameraCaptureSession;Landroid/os/Handler;)V

    return-object v0
.end method


# virtual methods
.method public captureBurstRequests(Ljava/util/List;Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I
    .locals 1

    .line 145
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;

    invoke-interface {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;->captureBurstRequests(Ljava/util/List;Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I

    move-result p1

    return p1
.end method

.method public setSingleRepeatingRequest(Landroid/hardware/camera2/CaptureRequest;Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I
    .locals 1

    .line 274
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;

    invoke-interface {v0, p1, p2, p3}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;->setSingleRepeatingRequest(Landroid/hardware/camera2/CaptureRequest;Ljava/util/concurrent/Executor;Landroid/hardware/camera2/CameraCaptureSession$CaptureCallback;)I

    move-result p1

    return p1
.end method

.method public toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;
    .locals 1

    .line 96
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->mImpl:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;

    invoke-interface {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat$CameraCaptureSessionCompatImpl;->unwrap()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object v0

    return-object v0
.end method
