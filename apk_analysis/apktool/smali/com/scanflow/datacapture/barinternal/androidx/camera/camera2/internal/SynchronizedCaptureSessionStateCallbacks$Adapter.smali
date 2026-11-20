.class Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;
.super Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;
.source "SynchronizedCaptureSessionStateCallbacks.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = "Adapter"
.end annotation


# instance fields
.field private final mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;


# direct methods
.method constructor <init>(Landroid/hardware/camera2/CameraCaptureSession$StateCallback;)V
    .locals 0

    .line 113
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;-><init>()V

    .line 114
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    return-void
.end method

.method constructor <init>(Ljava/util/List;)V
    .locals 0

    .line 118
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/CameraCaptureSessionStateCallbacks;->createComboCallback(Ljava/util/List;)Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    move-result-object p1

    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;-><init>(Landroid/hardware/camera2/CameraCaptureSession$StateCallback;)V

    return-void
.end method


# virtual methods
.method public onActive(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 1

    .line 137
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    .line 138
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object p1

    .line 137
    invoke-virtual {v0, p1}, Landroid/hardware/camera2/CameraCaptureSession$StateCallback;->onActive(Landroid/hardware/camera2/CameraCaptureSession;)V

    return-void
.end method

.method public onCaptureQueueEmpty(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 1

    .line 144
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    .line 145
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object p1

    .line 144
    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/ApiCompat$Api26Impl;->onCaptureQueueEmpty(Landroid/hardware/camera2/CameraCaptureSession$StateCallback;Landroid/hardware/camera2/CameraCaptureSession;)V

    return-void
.end method

.method public onClosed(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 1

    .line 162
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    .line 163
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object p1

    .line 162
    invoke-virtual {v0, p1}, Landroid/hardware/camera2/CameraCaptureSession$StateCallback;->onClosed(Landroid/hardware/camera2/CameraCaptureSession;)V

    return-void
.end method

.method public onConfigureFailed(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 1

    .line 156
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    .line 157
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object p1

    .line 156
    invoke-virtual {v0, p1}, Landroid/hardware/camera2/CameraCaptureSession$StateCallback;->onConfigureFailed(Landroid/hardware/camera2/CameraCaptureSession;)V

    return-void
.end method

.method public onConfigured(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 1

    .line 150
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    .line 151
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object p1

    .line 150
    invoke-virtual {v0, p1}, Landroid/hardware/camera2/CameraCaptureSession$StateCallback;->onConfigured(Landroid/hardware/camera2/CameraCaptureSession;)V

    return-void
.end method

.method public onReady(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 1

    .line 131
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    .line 132
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object p1

    .line 131
    invoke-virtual {v0, p1}, Landroid/hardware/camera2/CameraCaptureSession$StateCallback;->onReady(Landroid/hardware/camera2/CameraCaptureSession;)V

    return-void
.end method

.method onSessionFinished(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 0

    .line 169
    return-void
.end method

.method public onSurfacePrepared(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;Landroid/view/Surface;)V
    .locals 1

    .line 125
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSessionStateCallbacks$Adapter;->mCameraCaptureSessionStateCallback:Landroid/hardware/camera2/CameraCaptureSession$StateCallback;

    .line 126
    invoke-interface {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;->toCameraCaptureSessionCompat()Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;

    move-result-object p1

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCaptureSessionCompat;->toCameraCaptureSession()Landroid/hardware/camera2/CameraCaptureSession;

    move-result-object p1

    .line 125
    invoke-static {v0, p1, p2}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/ApiCompat$Api23Impl;->onSurfacePrepared(Landroid/hardware/camera2/CameraCaptureSession$StateCallback;Landroid/hardware/camera2/CameraCaptureSession;Landroid/view/Surface;)V

    return-void
.end method
