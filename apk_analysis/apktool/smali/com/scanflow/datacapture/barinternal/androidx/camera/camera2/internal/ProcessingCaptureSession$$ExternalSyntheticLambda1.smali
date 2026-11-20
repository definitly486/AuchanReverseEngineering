.class public final synthetic Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Landroidx/camera/core/impl/utils/futures/AsyncFunction;


# instance fields
.field public final synthetic f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession;

.field public final synthetic f$1:Landroidx/camera/core/impl/SessionConfig;

.field public final synthetic f$2:Landroid/hardware/camera2/CameraDevice;

.field public final synthetic f$3:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;


# direct methods
.method public synthetic constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession;Landroidx/camera/core/impl/SessionConfig;Landroid/hardware/camera2/CameraDevice;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$1:Landroidx/camera/core/impl/SessionConfig;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$2:Landroid/hardware/camera2/CameraDevice;

    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$3:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;

    return-void
.end method


# virtual methods
.method public final apply(Ljava/lang/Object;)Lcom/google/common/util/concurrent/ListenableFuture;
    .locals 4

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$1:Landroidx/camera/core/impl/SessionConfig;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$2:Landroid/hardware/camera2/CameraDevice;

    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession$$ExternalSyntheticLambda1;->f$3:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;

    check-cast p1, Ljava/util/List;

    invoke-static {v0, v1, v2, v3, p1}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession;->$r8$lambda$dZ2c23B5-bVnn66XeR4ziZkVHU8(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/ProcessingCaptureSession;Landroidx/camera/core/impl/SessionConfig;Landroid/hardware/camera2/CameraDevice;Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/SynchronizedCaptureSession$Opener;Ljava/util/List;)Lcom/google/common/util/concurrent/ListenableFuture;

    move-result-object p1

    return-object p1
.end method
