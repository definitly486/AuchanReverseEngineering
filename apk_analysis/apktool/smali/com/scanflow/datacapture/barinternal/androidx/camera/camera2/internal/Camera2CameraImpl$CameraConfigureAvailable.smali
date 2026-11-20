.class final Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$CameraConfigureAvailable;
.super Ljava/lang/Object;
.source "Camera2CameraImpl.java"

# interfaces
.implements Landroidx/camera/core/impl/CameraStateRegistry$OnConfigureAvailableListener;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x10
    name = "CameraConfigureAvailable"
.end annotation


# instance fields
.field final synthetic this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;


# direct methods
.method constructor <init>(Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;)V
    .locals 0

    .line 2529
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$CameraConfigureAvailable;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public onConfigureAvailable()V
    .locals 2

    .line 2534
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$CameraConfigureAvailable;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;

    iget-object v0, v0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;->mState:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    sget-object v1, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;->OPENED:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$InternalState;

    if-ne v0, v1, :cond_0

    .line 2535
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl$CameraConfigureAvailable;->this$0:Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;

    invoke-virtual {v0}, Lcom/scanflow/datacapture/barinternal/androidx/camera/camera2/internal/Camera2CameraImpl;->openCaptureSession()V

    :cond_0
    return-void
.end method
