.class public abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$StateCallback;
.super Ljava/lang/Object;
.source "SynchronizedCaptureSession.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x409
    name = "StateCallback"
.end annotation


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 311
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method onActive(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 0

    .line 319
    return-void
.end method

.method onCaptureQueueEmpty(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 0

    .line 324
    return-void
.end method

.method public onClosed(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
    .locals 0

    .line 357
    return-void
.end method

.method public abstract onConfigureFailed(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
.end method

.method abstract onConfigured(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
.end method

.method abstract onReady(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
.end method

.method abstract onSessionFinished(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;)V
.end method

.method onSurfacePrepared(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession;Landroid/view/Surface;)V
    .locals 0

    .line 330
    return-void
.end method
