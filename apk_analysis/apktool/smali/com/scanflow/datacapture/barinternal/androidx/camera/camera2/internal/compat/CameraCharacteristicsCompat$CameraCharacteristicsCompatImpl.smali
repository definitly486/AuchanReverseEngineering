.class public interface abstract Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCharacteristicsCompat$CameraCharacteristicsCompatImpl;
.super Ljava/lang/Object;
.source "CameraCharacteristicsCompat.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/compat/CameraCharacteristicsCompat;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x609
    name = "CameraCharacteristicsCompatImpl"
.end annotation


# virtual methods
.method public abstract get(Landroid/hardware/camera2/CameraCharacteristics$Key;)Ljava/lang/Object;
.end method

.method public abstract getPhysicalCameraIds()Ljava/util/Set;
.end method

.method public abstract unwrap()Landroid/hardware/camera2/CameraCharacteristics;
.end method
