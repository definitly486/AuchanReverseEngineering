.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator;
.super Ljava/lang/Object;
.source "CameraCoordinator.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator$ConcurrentCameraModeListener;
    }
.end annotation


# virtual methods
.method public abstract addListener(Lcom/scanflow/datacapture/barinternal/androidx/camera/core/concurrent/CameraCoordinator$ConcurrentCameraModeListener;)V
.end method

.method public abstract getCameraOperatingMode()I
.end method

.method public abstract getPairedConcurrentCameraId(Ljava/lang/String;)Ljava/lang/String;
.end method

.method public abstract setCameraOperatingMode(I)V
.end method
